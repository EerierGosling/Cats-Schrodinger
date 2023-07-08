using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionShower : MonoBehaviour
{
    public Canvas optionsCanvas;
    public GameObject optionsParent;
    public GameObject buttonPrefab;
    public TimelineManager timelineManager;

    void Start()
    {
        timelineManager.OnRealitySwap += RemoveButtons;
    }

    public void RemoveButtons(string id)
    {
        foreach (Transform child in optionsParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public List<GameObject> CreateButtons(string[] text, float spacing = 550f)
    {
        List<GameObject> buttons = new List<GameObject>();

        float x = - ((text.Length - 1) * spacing / 2f);

        for (int i = 0; i < text.Length; i++)
        {
            buttons.Add(CreateButton(text[i], x, 0));

            x += spacing;
        }
        return buttons;
    }

    public GameObject CreateButton(string text, float x, float y)
    {
        GameObject button = Instantiate(buttonPrefab, optionsParent.transform);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        button.GetComponent<FitText>().UpdateText(text);
        return button;
    }
}
