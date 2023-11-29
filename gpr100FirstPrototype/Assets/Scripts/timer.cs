using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    //aimed time in seconds (240) multiplied by 60 due to frames per second, I need to change this for this project based on the time limit we decide on
    private int timeGoal = 14400;
    //private int timeGoal = 120;
    private int convTime = 0;
    private int convSec = 0;
    public pause timerEnd;
    public TextMeshProUGUI timeDisp;
    private bool pauseCheck;
    public GameObject enemy;
    public GameObject speedy;
    public GameObject tanky;
    public GameObject boss1;
    public TextMeshProUGUI scoreDisp;
    public Transform spawnPoint;
    private int score;
    private int xRand, yRand, negXRand, negYRand, spawnNum;
    private bool bossHappen = false;
    // Start is called before the first frame update
    void Start()
    {

        QualitySettings.vSyncCount = 0;  // this disables vsync so I can set the frame rate to limit the timer
        Application.targetFrameRate = 60; // hoepfully limit the frame rate
    }
    private void spawner(int spawnNum, GameObject spawn, Vector3 additive)
    {
        for(int i = 1; i <= spawnNum; i++)
        {
            GameObject spawned = Instantiate(spawn, spawnPoint.position + additive, spawnPoint.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        scoreDisp.text = score.ToString();
        xRand = Random.Range(10, 30);
        yRand = Random.Range(10, 30);
        spawnNum = Random.Range(1, 4);
        negXRand = Random.Range(-10, -30);
        negYRand = Random.Range(-10, -30);
        Vector3 additive1 = new Vector3(xRand, yRand, 0f);
        Vector3 additive2 = new Vector3(negXRand, negYRand, 0f);
        Vector3 additive3 = new Vector3(xRand, negYRand, 0f);
        Vector3 additive4 = new Vector3(negXRand, yRand, 0f);
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
            if(timeGoal <= 7200 && bossHappen != true)
            {
                GameObject spawned = Instantiate(boss1, spawnPoint.position + additive1, spawnPoint.rotation);
                bossHappen = true;
            }
            if(timeGoal % 60 == 0)
            {
                if(spawnNum == 1)
                {
                    if(convTime < 1)
                     {
                        spawner(4, enemy, additive1);
                    }
                    else if(convTime < 2)
                    {
                        spawner(4, enemy, additive1);
                    }
                    else if (convTime < 3)
                    {
                        spawner(3, enemy, additive1);
                    }
                    else
                    {
                        spawner(2, enemy, additive1);
                    }
                }
                else if (spawnNum == 2)
                {
                    if (convTime < 1)
                    {
                        spawner(4, speedy, additive1);
                    }
                    else if (convTime < 2)
                    {
                        spawner(4, speedy, additive1);
                    }
                    else if (convTime < 3)
                    {
                        spawner(3, speedy, additive1);
                    }
                    else
                    {
                        spawner(2, speedy, additive1);
                    }

                }
                else if (spawnNum == 3)
                    {
                    if (convTime < 1)
                    {
                        spawner(4, tanky, additive1);
                    }
                    else if (convTime < 2)
                    {
                        spawner(4, tanky, additive1);
                    }
                    else if (convTime < 3)
                    {
                        spawner(3, tanky, additive1);
                    }
                    else
                    {
                        spawner(2, tanky, additive1);
                    }
                }

            }
            

            timeDisp.text = convTime.ToString() + ":" + convSec.ToString();
            if(convSec < 10)
            {
                timeDisp.text = convTime.ToString() + ":0" + convSec.ToString();
            }
        }

    }
}
