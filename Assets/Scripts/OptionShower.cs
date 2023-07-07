using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionShower : MonoBehaviour
{
    public Canvas optionsCanvas;
    public GameObject buttonPrefab;

    public GameObject CreateButton(string text, float x, float y)
    {
        GameObject button = Instantiate(buttonPrefab, optionsCanvas.transform);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        button.GetComponentInChildren<TextMeshProUGUI>().text = text;
        return button;
    }
}
