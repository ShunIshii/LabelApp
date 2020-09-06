using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject graphPanel;
    private GraphGenerator graphGenerator;

    [SerializeField] private GameObject video;
    private VideoManager videoManager;

    [SerializeField] private GameObject currentBar;
    private CurrentBarBehaviour currentBarBehaviour;

    public bool isGaming = false;

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

    public void OnClickStarPauseButton()
    {
        if (!isGaming)
        {
            GameStart();
        }
        else
        {
            GamePause();
        }
    }

    public void GameStart()
    {
        isGaming = true;
        videoManager.VideoStart();
        currentBarBehaviour.CurrentBarStart();
    }

    public void GamePause()
    {
        isGaming = false;
        videoManager.VideoPause();
        currentBarBehaviour.CurrentBarPause();
    }

    public void OnClickStopButton()
    {
        GameStop();
    }

    public void GameStop()
    {
        isGaming = false;
        videoManager.VideoStop();
        currentBarBehaviour.CurrentBarStop();
    }

    public void OnClickInitButton()
    {
        GameInit();
    }

    public void GameInit()
    {
        SceneManager.LoadScene(0);
    }
}
