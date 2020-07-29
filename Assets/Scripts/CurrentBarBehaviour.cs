using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CurrentBarBehaviour : MonoBehaviour
{
    private float startPosX;
    [SerializeField] private GameObject graphPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetStartPos()
    {
        var graphWidth = graphPanel.GetComponent<RectTransform>().sizeDelta.x;
        startPosX = -(graphWidth / 2);
        transform.position = transform.position + new Vector3(startPosX, 0, 0);
    }

    public void OnClickSetStartButton()
    {
        SetStartPos();
    }
}
