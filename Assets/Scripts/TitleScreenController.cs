using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TitleScreenController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject overlay;
    public AudioSource music;
    

    // Start is called before the first frame update
    void Start()
    {
        overlay.SetActive(false);
        videoPlayer.loopPointReached += ShowTitle;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowTitle(VideoPlayer vp)
    {
        overlay.SetActive(true);
        music.Play();
    }
}
