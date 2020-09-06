using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEditor;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private CurrentBarBehaviour currentBarBehaviour;
    private long videoStartFrame;

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

    public void VideoStop()
    {
        videoPlayer.Pause();
        videoPlayer.frame = videoStartFrame;
    }

    public void OnClickSelectButton()
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = EditorUtility.OpenFilePanel("Select video", "", "MOV, mp4");
    }

    public void OnClickSetStartButton()
    {
        videoStartFrame = videoPlayer.frame;
    }
}
