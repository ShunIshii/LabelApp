using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject graphPanel;
    private GraphGenerator graphGenerator;

    [SerializeField] private GameObject video;
    private VideoManager videoManager;

    [SerializeField] private GameObject currentBar;
    private CurrentBarBehaviour currentBarBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        graphGenerator = graphPanel.GetComponent<GraphGenerator>();
        videoManager = video.GetComponent<VideoManager>();
        currentBarBehaviour = currentBar.GetComponent<CurrentBarBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStopButton()
    {
        GameStop();
    }

    public void GameStop()
    {
        currentBarBehaviour.CurrentBarStop();
        videoManager.VideoStop();
    }
}
