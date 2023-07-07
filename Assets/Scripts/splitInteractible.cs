using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class splitInteractible : MonoBehaviour
{
    TimelineManager timelineManager;
    OptionShower optionShower;

    public string[] messages;
    public string[] splits;

    void Start()
    {
        timelineManager = GameObject.FindObjectOfType<TimelineManager>();
        optionShower = GameObject.FindObjectOfType<OptionShower>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }

    public void Interact()
    {
        List<GameObject> buttons = optionShower.CreateButtons(messages);

        foreach (GameObject button in buttons)
        {
            button.GetComponent<Button>().onClick.AddListener(() => {
                timelineManager.SwapReality(splits[buttons.IndexOf(button)]);
            });
        }
    }
}