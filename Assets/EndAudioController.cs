using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class EndAudioController : MonoBehaviour
{
    public AudioSource endMusic;

    // Start is called before the first frame update
    void Start()
    {
        endMusic.Play();
    }
}
