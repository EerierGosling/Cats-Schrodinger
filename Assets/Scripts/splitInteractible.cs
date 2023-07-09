using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class splitInteractible : MonoBehaviour
{
    private OptionShower optionShower;
    private GameObject cat;
    private GameObject prompt;
    private InventoryManager inventoryManager;

    public GameObject promptPrefab;
    public string requiredItem = null;
    public string text1;
    public string text2;
    public string load1;
    public string load2;
    public SceneManager sceneManager;
    

    void Start()
    {
        // get the object tagged "Player"
        cat = GameObject.FindGameObjectWithTag("Player");
        optionShower = GameObject.FindObjectOfType<OptionShower>();
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>();

        prompt = Instantiate(promptPrefab, transform.position, Quaternion.identity);
        // place it above the object
        prompt.transform.position += new Vector3(0, 1f, 0);

        // make it a child of the object
        prompt.transform.parent = transform;
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
        if (!inventoryManager.HasItem(requiredItem) && requiredItem != "")
        {
            inventoryManager.ShowPopup("You are missing something...", 3f);
            return;
        }

        if(this.gameObject.name != "FrontDoor")
        {
            optionShower.OpenNav(text1, text2, load1, load2);
            inventoryManager.RemoveItem(requiredItem);
        } else
        {
            SceneManager.LoadScene("Win");
            inventoryManager.RemoveItem(requiredItem);
        }
    }
}