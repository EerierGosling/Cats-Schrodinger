using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionShower : MonoBehaviour
{
    public TimelineManager timelineManager;
    public Canvas optionsCanvas;
    public GameObject buttonPrefab;

    public float ButtonSpacing = 100f;
    public float topOffset = 100f;

    void Start()
    {
        // show the buttons for the current reality
        ShowButtons();
    }

    public void ShowButtons()
    {
        string[] options = timelineManager.CurrentReality.paths;

        float x = - ((options.Length - 1) * ButtonSpacing / 2);

        float y = optionsCanvas.GetComponent<RectTransform>().rect.height / 2 - topOffset;

        // add a button for each option
        foreach (string option in options) {
            // place the button at the top of the screen
            GameObject button = CreateButton(option, x, y);
            x += ButtonSpacing;
            
            // add a click handler to the button
            button.GetComponent<Button>().onClick.AddListener(() => {
                timelineManager.LoadReality(option);
            });
        }
    }

    public GameObject CreateButton(string text, float x, float y)
    {
        GameObject button = Instantiate(buttonPrefab, optionsCanvas.transform);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        button.GetComponentInChildren<TextMeshProUGUI>().text = text;
        return button;
    }
}
