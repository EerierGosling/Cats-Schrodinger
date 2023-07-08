using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FitText : MonoBehaviour
{
   TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateText(string newText)
    {
        text.text = newText;
        text.ForceMeshUpdate();

        // fit the button to the text
        RectTransform rectTransform = GetComponent<RectTransform>();

        float buttonWidth = text.preferredWidth + 20f;
        float buttonHeight = text.preferredHeight;

        rectTransform.sizeDelta = new Vector2(buttonWidth, buttonHeight);
    }
}
