using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TitleScreenController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject overlay;
    public AudioSource music;
    public TMPro.TextMeshProUGUI skipText;


    // Start is called before the first frame update
    void Start()
    {
        skipText.gameObject.SetActive(true);
        overlay.SetActive(false);
        music.Stop();
        videoPlayer.loopPointReached += ShowTitle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            videoPlayer.frame = (long)videoPlayer.frameCount - 1;
            videoPlayer.Play();
        }
    }

    void ShowTitle(VideoPlayer vp)
    {
        skipText.gameObject.SetActive(false);
        overlay.SetActive(true);
        music.Play();
        videoPlayer.loopPointReached -= ShowTitle;
    }
}
