using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public List<Image> Icons;
    public GameObject popupText;
    
    private List<string> items = new List<string>();

    public void ShowPopup(string text, float duration)
    {
        popupText.SetActive(true);

        popupText.GetComponent<TextMeshProUGUI>().text = text;

        StartCoroutine(HidePopupAfterDelay(duration));
    }

    IEnumerator HidePopupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        popupText.SetActive(false);
    }

    public void AddItem(string id, Sprite icon)
    {
        if(items.Contains(id))
            return;

        if(items.Count >= Icons.Count)
            return;

        items.Add(id);
        Icons[items.Count - 1].sprite = icon;
    }

    public void RemoveItem(string id)
    {
        if(!items.Contains(id))
            return;

        items.Remove(id);
        Icons[items.Count].sprite = null;
    }

    public void Clear()
    {
        items.Clear();
        foreach(var icon in Icons)
            icon.sprite = null;
    }

    public bool HasItem(string id)
    {
        return items.Contains(id);
    }
}
