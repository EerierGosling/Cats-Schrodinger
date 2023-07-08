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
    public Vector3 button1Pos;
    public Vector3 button2Pos;
    
    public GameObject dimmer;
    public LineAnimator line1;
    public LineAnimator line2;

    void Start()
    {
        timelineManager.OnRealitySwap += RemoveButtons;
    }

    public void RemoveButtons(string id)
    {
        dimmer.SetActive(false);
        line1.Reset();
        line2.Reset();

        foreach (Transform child in optionsParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void OpenNav(string text1, string text2, string load1, string load2)
    {
        dimmer.SetActive(true);

        line1.beginAnimation();
        line2.beginAnimation();

        // create the buttons after 1 second
        StartCoroutine(CreateButtonsAfterDelay(text1, text2, load1, load2, 1f));
    }

    IEnumerator CreateButtonsAfterDelay(string text1, string text2, string load1, string load2, float delay)
    {
        yield return new WaitForSeconds(delay);
        CreateButtons(text1, text2, load1, load2);
    }

    void CreateButtons(string text1, string text2, string load1, string load2)
    {
        GameObject button1 = CreateButton(text1, button1Pos.x, button1Pos.y);
        GameObject button2 = CreateButton(text2, button2Pos.x, button2Pos.y);

        button1.GetComponent<Button>().onClick.AddListener(() => timelineManager.SwapReality(load1));
        button2.GetComponent<Button>().onClick.AddListener(() => timelineManager.SwapReality(load2));
    }

    public GameObject CreateButton(string text, float x, float y)
    {
        GameObject button = Instantiate(buttonPrefab, optionsParent.transform);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        button.GetComponent<FitText>().UpdateText(text);
        return button;
    }
}
