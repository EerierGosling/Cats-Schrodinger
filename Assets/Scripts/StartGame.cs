using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        // when the button is pressed, load "main" scene
        GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("main"));
    }
}
