using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    //aimed time in seconds (240) multiplied by 60 due to frames per second, I need to change this for this project based on the time limit we decide on
    private int timeGoal = 14400;
    private int convTime = 0;
    private int convSec = 0;
    public pause timerEnd;
    public TextMeshProUGUI timeDisp;
    private bool pauseCheck;
    // Start is called before the first frame update
    void Start()
    {

        QualitySettings.vSyncCount = 0;  // this disables vsync so I can set the frame rate to limit the timer
        Application.targetFrameRate = 60; // hoepfully limit the frame rate
    }

    // Update is called once per frame
    void Update()
    {
        pauseCheck = timerEnd.getPause();
        /*if(boss.Alive() == true)
         * {
         *      do nothing
         * }
         * else{ everything else in program
         * this is to avoid timer progressing when the boss is present
         * also add an if to check if the game is paused
         * */
        if(pauseCheck != true)
        {
            timeGoal--;
            if (timeGoal <= 0)
            {
                timerEnd.changeScene();
            }
            convTime = (timeGoal / 60) / 60;
            convSec = (timeGoal / 60) % 60;

            timeDisp.text = convTime.ToString() + ":" + convSec.ToString();
        }

    }
}
