using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public List<string> realityIds;
    public List<GameObject> realityPrefabs;
    public GameObject realityContainer;

    public string currentRealityId;

    public DimController dimController;

    void Start()
    {
        SwapReality("root");
    }

    public event Action<string> OnRealitySwap;

    public void SwapReality(string id)
    {
        currentRealityId = id;

        if (currentRealityId == "root") {
            dimController.DimControl(true);
        }
        else {
            dimController.DimControl(false);
        }

        OnRealitySwap?.Invoke(id);

        // clear the reality container
        foreach (Transform child in realityContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // instantiate the new reality
        GameObject newReality = Instantiate(realityPrefabs[realityIds.IndexOf(id)], realityContainer.transform);
        // newReality.transform.localPosition = Vector3.zero;

        // append it to the reality container
        newReality.transform.SetParent(realityContainer.transform, false);
    }
}
