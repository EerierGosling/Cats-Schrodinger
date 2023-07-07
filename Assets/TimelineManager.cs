using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Timeline;

public class TimelineManager : MonoBehaviour
{
    public StringSO currentRealityId;
    
    public void LoadReality(string id)
    {
        currentRealityId.Value = id;

        // load the scene with the given id
        SceneManager.LoadScene(id);
    }

    public Reality CurrentReality {
        get {
            return Realities.realities.GetValueOrDefault(currentRealityId.Value);
        }
    }
}