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
    private bool isMoving = false;

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
        barStartPos = transform.position + new Vector3(-(graphWidth / 2), 0, 0);
        transform.position = barStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
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

    public void CurrentBarStart()
    {
        isMoving = true;
    }

    public void CurrentBarPause()
    {
        isMoving = false;
    }

    public void CurrentBarStop()
    {
        isMoving = false;
        SetStartPos();
    }

    private void SetStartPos()
    {
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

    public void OnClickPoint(int pointIndex)
    {
        GameObject p = graphGenerator.pointsList[pointIndex];
        transform.position = new Vector3(p.transform.position.x, transform.position.y, transform.position.z);
        time = (float)graphGenerator.accList[pointIndex].elaspedTime;
        arrayIndex = pointIndex;
    }
}
