using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CurrentBarBehaviour : MonoBehaviour
{
    private Vector3 barStartPos;
    private float time = 0f;
    private int arrayIndex = 0;
    private bool isActive = false;
    private GraphGenerator graphGenerator;
    [SerializeField] private GameObject graphPanel;

    // Start is called before the first frame update
    void Start()
    {
        graphGenerator = GameObject.Find("GraphPanel").GetComponent<GraphGenerator>();
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
            if (graphGenerator.accList[arrayIndex].elaspedTime <= time)
            {
                while (graphGenerator.accList[arrayIndex].elaspedTime <= time)
                {
                    arrayIndex++;
                }
                transform.position = new Vector3(graphGenerator.pointsList[arrayIndex].transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }

    public void VideoStart()
    {
        isActive = true;
        Debug.Log("Start!");
    }

    public void VideoPause()
    {
        isActive = false;
    }

    public void VideoReset()
    {
        isActive = false;
        time = 0f;
        arrayIndex = 0;
        transform.position = barStartPos;
    }

    void SetStartPos()
    {
        transform.position = barStartPos;
    }

    public void OnClickSetStartButton()
    {
        SetStartPos();
    }
}
