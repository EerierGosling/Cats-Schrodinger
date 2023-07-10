using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{

    public GameObject chairUp;
    public GameObject chairTilt;

    public GameObject safeClosed;
    public GameObject safeOpen;

    //public List<GameObject> Reality1 = { chairUp, safeClosed };
    //public List<GameObject> Reality2 = { chairUp, safeClosed };
    //public List<GameObject> Reality3 = { chairUp, safeClosed };
    //public List<GameObject> Reality4 = { chairUp, safeClosed };
    //public List<GameObject> Reality5 = { chairUp, safeClosed };
    //public List<GameObject> Reality6 = { chairUp, safeClosed };

    //public List<GameObject> Reality7 = { chairUp, safeClosed };

    //List<List<GameObject>> AllRealities = { Reality1, Reality2, Reality3, Reality4, Reality5, Reality6, Reality7 };

    public List<string> realityIds;
    public List<GameObject> realityPrefabs;
    public GameObject realityContainer;

    public string currentRealityId;

    void Start()
    {
        SwapReality("root");
    }

    public event Action<string> OnRealitySwap;

    public void SwapReality(string id)
    {
        currentRealityId = id;

        OnRealitySwap?.Invoke(id);

        // clear the reality container
        foreach (Transform child in realityContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // instantiate the new reality
        //foreach (var sceneObject in AllRealities[id])
        //{

        //}

        GameObject newReality = Instantiate(realityPrefabs[realityIds.IndexOf(id)], realityContainer.transform);
        // newReality.transform.localPosition = Vector3.zero;

        // append it to the reality container
        newReality.transform.SetParent(realityContainer.transform, false);
    }
}


