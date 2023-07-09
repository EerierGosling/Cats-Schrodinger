using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatTreeInteractable : MonoBehaviour
{
    public GameObject promptPrefab;
    public SceneManager sceneManager;

    private InventoryManager invManager;
    private GameObject prompt;
    private GameObject cat;

    private bool moved = false;

    void Awake()
    {
        cat = GameObject.FindGameObjectWithTag("Player");
        invManager = FindObjectOfType<InventoryManager>();

        prompt = Instantiate(promptPrefab, transform.position, Quaternion.identity);

        prompt.transform.position += new Vector3(0, 1f, 0);
        prompt.transform.parent = transform;
    }

    void Update()
    {
        if(!prompt) return;

        // get the distance to the player
        float distance = Vector3.Distance(cat.transform.position, transform.position);

        // if the player is close enough, show the prompt
        prompt.SetActive(distance < 1.5f);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            // if the player is close enough, interact
            if(distance < 1.5f) Interact();
        }
    }

    void Interact()
    {
        if (moved) {
            SceneManager.LoadScene("Win");
            invManager.RemoveItem("screwdriver");
            invManager.RemoveItem("rope");
        }
        if (!(invManager.HasItem("screwdriver") && invManager.HasItem("rope")))
        {
            invManager.ShowPopup("You are missing something...", 3f);
            return;
        }
        else {
            transform.position -= new Vector3(1.25f, 0, 0);
            invManager.RemoveItem("screwdriver");
            invManager.RemoveItem("rope");
            moved = true;
            return;
        }
    }
}