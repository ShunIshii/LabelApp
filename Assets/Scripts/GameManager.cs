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

    public bool isGaming = false;

    // Start is called before the first frame update
    void Start()
    {
        graphGenerator = graphPanel.GetComponent<GraphGenerator>();
        videoManager = video.GetComponent<VideoManager>();
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
    }

    public void GamePause()
    {
        isGaming = false;
        videoManager.VideoPause();
    }

    public void OnClickStopButton()
    {
        GameStop();
    }

    public void GameStop()
    {
        isGaming = false;
        videoManager.VideoStop();
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
