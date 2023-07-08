using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class splitInteractible : MonoBehaviour
{
    private TimelineManager timelineManager;
    private OptionShower optionShower;
    private GameObject cat;
    private GameObject prompt;

    public GameObject promptPrefab;
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

        prompt = Instantiate(promptPrefab, transform.position, Quaternion.identity);
        // place it above the object
        prompt.transform.position += new Vector3(0, 1f, 0);
    }

    void Update()
    {
        // get the distance to the player
        float distance = Vector3.Distance(cat.transform.position, transform.position);

        // if the player is close enough, show the prompt
        prompt.SetActive(distance < 1.5f);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {

            // if the player is close enough, interact
            if(distance < 1.5f) Interact();
            // Interact();
        }
    }

    public void Interact()
    {
        optionShower.OpenNav(text1, text2, load1, load2);
    }
}