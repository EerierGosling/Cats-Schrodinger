using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reset : MonoBehaviour
{
    TimelineManager timelineManager;
    Button button;

    void Start()
    {
        timelineManager = GameObject.FindObjectOfType<TimelineManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void Update()
    {
        button.interactable = timelineManager.currentRealityId != "root";
    }

    void OnButtonClick()
    {
        timelineManager.SwapReality("root");
    }
}