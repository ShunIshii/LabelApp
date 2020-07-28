using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEditor;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;

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
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();
        }
    }

    public void OnClickSelectButton()
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = EditorUtility.OpenFilePanel("Select video", "", "mov, mp4");
    }
}
