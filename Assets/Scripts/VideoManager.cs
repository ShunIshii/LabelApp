using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEditor;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private long videoStartFrame;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartPauseButton()
    {
        if (!videoPlayer.isPlaying)
        {
            VideoStart();
        }
        else
        {
            VideoPause();
        }
    }

    public void VideoStart()
    {
        videoPlayer.Play();
    }

    public void VideoPause()
    {
        videoPlayer.Pause();
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
