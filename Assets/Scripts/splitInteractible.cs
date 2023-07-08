using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class splitInteractible : MonoBehaviour
{
    private TimelineManager timelineManager;
    private OptionShower optionShower;
    private GameObject cat;

    public string text1;
    public string text2;
    public string load1;
    public string load2;

    void Start()
    {
        // get the object tagged "Player"
        cat = GameObject.FindGameObjectWithTag("Player");
        timelineManager = GameObject.FindObjectOfType<TimelineManager>();
        optionShower = GameObject.FindObjectOfType<OptionShower>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            // get the distance to the player
            float distance = Vector3.Distance(cat.transform.position, transform.position);

            // if the player is close enough, interact
            if(distance < 1.5f) Interact();
        }
    }

    public void Interact()
    {
        optionShower.OpenNav(text1, text2, load1, load2);
    }
}