using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CurrentBarBehaviour : MonoBehaviour
{
    private Vector3 barStartPos;
    private float startTime = 0f;
    private float time = 0f;
    private int arrayIndex = 0;
    private int startIndex = 0;
    private int arrayLength = 0;
    private bool isActive = false;

    [SerializeField] private GameObject graphPanel;
    private GraphGenerator graphGenerator;

    [SerializeField] private GameObject gameManagerObj;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        graphGenerator = graphPanel.GetComponent<GraphGenerator>();
        gameManager = gameManagerObj.GetComponent<GameManager>();

        var graphWidth = graphPanel.GetComponent<RectTransform>().sizeDelta.x;
        transform.position = transform.position + new Vector3(-(graphWidth / 2), 0, 0);
        barStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            time += Time.deltaTime;
            while (graphGenerator.accList[arrayIndex].elaspedTime < time)
            {
                arrayIndex++;
                if (arrayIndex == arrayLength)
                {
                    gameManager.GameStop();
                }
            }
            transform.position = new Vector3(graphGenerator.pointsList[arrayIndex].transform.position.x, transform.position.y, transform.position.z);
        }
    }

    public void VideoStart()
    {
        isActive = true;
    }

    public void VideoPause()
    {
        isActive = false;
    }

    public void CurrentBarStop()
    {
        isActive = false;
        time = startTime;
        arrayIndex = startIndex;
        transform.position = barStartPos;
    }

    public void OnClickSetStartButton()
    {
        barStartPos = transform.position;
        startTime = time;
        startIndex = arrayIndex;
    }

    public void SetGraphInfo(int accListLength)
    {
        arrayLength = accListLength;
    }
}
