using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillPlayer : MonoBehaviour
{
    private DimController dimmer;
    private OptionShower optionShower;
    private InventoryManager inventoryManager;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
        dimmer = GameObject.FindObjectOfType<DimController>();
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>();
        optionShower = GameObject.FindObjectOfType<OptionShower>();
    
        dimmer.SetDim(0.65f, 0.5f, 0f, 0f);
        inventoryManager.ShowPopup("You died. Warp back to box? -->", 10f);
        optionShower.inMenu = true;
    }
}
