using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeLeft;
    public bool TimerOn = false;

    public Text Timertxt;


    void Start()
    {
        TimerOn = true;
    }
     
    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if(TimeLeft >= 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft); 
            }
            else
            {
                Debug.Log("Happy new yeaR!");
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                TimeLeft = 0;
                TimerOn = false;

            }



        }
    }

    void updateTimer(float currentTime)
    {
        currentTime -= 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        Timertxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }


}
