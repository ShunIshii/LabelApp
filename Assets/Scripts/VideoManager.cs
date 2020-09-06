using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEditor;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private CurrentBarBehaviour currentBarBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        currentBarBehaviour = GameObject.Find("CurrentBar").GetComponent<CurrentBarBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartPauseButton()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
            currentBarBehaviour.VideoStart();
        }
        else
        {
            videoPlayer.Pause();
            currentBarBehaviour.VideoPause();
        }
    }

    public void OnClickResetButton()
    {
        videoPlayer.Stop();
        currentBarBehaviour.VideoReset();
    }

    public void OnClickSelectButton()
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = EditorUtility.OpenFilePanel("Select video", "", "mov, mp4");
    }
}
