using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reset : MonoBehaviour
{
    TimelineManager timelineManager;

    void Start()
    {
        timelineManager = GameObject.FindObjectOfType<TimelineManager>();
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        timelineManager.SwapReality("root");
    }
}
