using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public GameObject promptPrefab;
    public string pickupText;
    public string grantItem;
    public Sprite grantItemSprite;

    private InventoryManager invManager;
    private GameObject prompt;
    private GameObject cat;

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
        if(grantItem != "")
        {
            invManager.AddItem(grantItem, grantItemSprite);
            Destroy(gameObject);
        }

        invManager.ShowPopup(pickupText, 5f);
    }
}