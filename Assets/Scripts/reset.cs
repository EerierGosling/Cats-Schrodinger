using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class reset : MonoBehaviour
{
    public TextMeshProUGUI text;

    private TimelineManager timelineManager;
    private Button button;
    private CatController catController;
    private AudioSource audioSource;

    void Start()
    {
        catController = GameObject.FindObjectOfType<CatController>();
        timelineManager = GameObject.FindObjectOfType<TimelineManager>();

        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        button.onClick.AddListener(OnButtonClick);
    }

    void Update()
    {
        button.interactable = timelineManager.currentRealityId != "root";
    }

    void OnButtonClick()
    {
        timelineManager.SwapReality("root");

        catController.ResetPos();

        audioSource.Play();

        text.text = "";
    }
}