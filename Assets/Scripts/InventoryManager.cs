using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public Image[] Icons;
    public GameObject popupText;
    
    private string[] items;

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
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == "" || items[i] == null)
            {
                items[i] = id;
                Icons[i].sprite = icon;
                Icons[i].enabled = true;
                return;
            }
        }
    }

    public void RemoveItem(string id)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == id)
            {
                items[i] = "";
                Icons[i].sprite = null;
                Icons[i].enabled = false;
                return;
            }
        }
    }

    void Start()
    {
        items = new string[Icons.Length];
    }

    public bool HasItem(string id)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == id) return true;
        }

        return false;
    }
}
