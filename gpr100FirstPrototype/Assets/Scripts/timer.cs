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
    public TextMeshProUGUI scoreDisp;
    private bool pauseCheck;
    public GameObject enemy;
    public GameObject speedy;
    public GameObject tanky;
    public GameObject boomy;
    public GameObject boss1;
    public GameObject powerUp;
    public Transform spawnPoint;
    public Transform pow1;
    public Transform pow2;
    public Transform pow3;
    public Transform pow4;
    public Transform pow5;
    public GameObject grayOut;
    private int xRand, yRand, negXRand, negYRand, spawnNum, powNum; 
    private float score = 0;
    private bool bossHappen = false;
    public PlayerShooting speedChange;
    private bool incSpeed = true, incSpeed2 = true, incSpeed3 = true, incSpeed4 = true;
    public HigherCaliberPowerupScript power;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        QualitySettings.vSyncCount = 0;  // this disables vsync so I can set the frame rate to limit the timer
        Application.targetFrameRate = 60; // hoepfully limit the frame rate

    }

    public void scoreChange(float amount)
    {
        score += amount;
    }

    // Update is called once per frame
    void Update()
    {
        grayOut.SetActive(false);
        if (score >=40 && incSpeed != false)
        {
                speedChange.shootSpeed(0.1f);
                incSpeed = false;
                Debug.Log("call shorten speed");
        }
        else if (score >= 80 && incSpeed2 != false)
        {
            speedChange.shootSpeed(0.1f);
            incSpeed2 = false;
            Debug.Log("call shorten speed");
        }
        else if (score >= 120 && incSpeed3 != false)
        {
            speedChange.shootSpeed(0.1f);
            incSpeed3 = false;
            Debug.Log("call shorten speed");
        }
        else if (score >= 160 && incSpeed4 != false)
        {
            speedChange.shootSpeed(0.1f);
            incSpeed4 = false;
            Debug.Log("call shorten speed");
        }
        xRand = Random.Range(10, 30);
        yRand = Random.Range(10, 30);
        spawnNum = Random.Range(1, 5);
        negXRand = Random.Range(-10, -30);
        negYRand = Random.Range(-10, -30);
        powNum = Random.Range(1, 5);
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
            if(timeGoal % 1800 == 0)
            {
                switch(powNum)
                {
                    case 1:
                        GameObject pows = Instantiate(powerUp, pow1.position, pow1.rotation);
                        break;
                    case 2:
                        GameObject pows2 = Instantiate(powerUp, pow2.position, pow1.rotation);
                        break;
                    case 3:
                        GameObject pows3 = Instantiate(powerUp, pow3.position, pow1.rotation);
                        break;
                    case 4:
                        GameObject pows4 = Instantiate(powerUp, pow4.position, pow1.rotation);
                        break;
                    case 5:
                        GameObject pows5 = Instantiate(powerUp, pow5.position, pow1.rotation);
                        break;
                }
            }
            if(timeGoal % 60 == 0)
            {
                if(spawnNum == 1)
                {
                    if(convTime < 1)
                     {
                        GameObject spawned = Instantiate(enemy, spawnPoint.position + additive1, spawnPoint.rotation);
                        GameObject spawned2 = Instantiate(enemy, spawnPoint.position + additive2, spawnPoint.rotation);
                        GameObject spawned3 = Instantiate(enemy, spawnPoint.position + additive3, spawnPoint.rotation);
                        GameObject spawned4 = Instantiate(enemy, spawnPoint.position + additive4, spawnPoint.rotation);
                        GameObject spawned5 = Instantiate(enemy, spawnPoint.position + additive1, spawnPoint.rotation);
                    }
                    else if(convTime < 2)
                    {
                        GameObject spawned = Instantiate(enemy, spawnPoint.position + additive3, spawnPoint.rotation);
                        GameObject spawned2 = Instantiate(enemy, spawnPoint.position + additive1, spawnPoint.rotation);
                        GameObject spawned3 = Instantiate(enemy, spawnPoint.position + additive2, spawnPoint.rotation);
                        GameObject spawned4 = Instantiate(enemy, spawnPoint.position + additive4, spawnPoint.rotation);

                    }
                    else if (convTime < 3)
                    {
                        GameObject spawned = Instantiate(enemy, spawnPoint.position + additive1, spawnPoint.rotation);
                        GameObject spawned2 = Instantiate(enemy, spawnPoint.position + additive4, spawnPoint.rotation);
                        GameObject spawned3 = Instantiate(enemy, spawnPoint.position + additive2, spawnPoint.rotation);
                    }
                    else
                    {
                        GameObject spawned = Instantiate(enemy, spawnPoint.position + additive1, spawnPoint.rotation);
                        GameObject spawned2 = Instantiate(enemy, spawnPoint.position + additive3, spawnPoint.rotation);
                    }
                }
                else if (spawnNum == 2)
                {
                    if (convTime < 1)
                    {
                        GameObject spawned = Instantiate(speedy, spawnPoint.position + additive1, spawnPoint.rotation);
                        GameObject spawned2 = Instantiate(speedy, spawnPoint.position + additive2, spawnPoint.rotation);
                        GameObject spawned3 = Instantiate(speedy, spawnPoint.position + additive3, spawnPoint.rotation);
                        GameObject spawned4 = Instantiate(speedy, spawnPoint.position + additive4, spawnPoint.rotation);
                        GameObject spawned5 = Instantiate(speedy, spawnPoint.position + additive1, spawnPoint.rotation);
                    }
                    else if (convTime < 2)
                    {
                        GameObject spawned = Instantiate(speedy, spawnPoint.position + additive3, spawnPoint.rotation);
                        GameObject spawned2 = Instantiate(speedy, spawnPoint.position + additive1, spawnPoint.rotation);
                        GameObject spawned3 = Instantiate(speedy, spawnPoint.position + additive2, spawnPoint.rotation);
                        GameObject spawned4 = Instantiate(speedy, spawnPoint.position + additive4, spawnPoint.rotation);

                    }
                    else if (convTime < 3)
                    {
                        GameObject spawned = Instantiate(speedy, spawnPoint.position + additive1, spawnPoint.rotation);
                        GameObject spawned2 = Instantiate(speedy, spawnPoint.position + additive4, spawnPoint.rotation);
                        GameObject spawned3 = Instantiate(speedy, spawnPoint.position + additive2, spawnPoint.rotation);
                    }
                    else
                    {
                        GameObject spawned = Instantiate(speedy, spawnPoint.position + additive1, spawnPoint.rotation);
                        GameObject spawned2 = Instantiate(speedy, spawnPoint.position + additive3, spawnPoint.rotation);
                    }
                    
                }
                else if (spawnNum == 3)
                    {
                        if (convTime < 1)
                        {
                            GameObject spawned = Instantiate(tanky, spawnPoint.position + additive1, spawnPoint.rotation);
                            GameObject spawned2 = Instantiate(tanky, spawnPoint.position + additive2, spawnPoint.rotation);
                            GameObject spawned3 = Instantiate(tanky, spawnPoint.position + additive3, spawnPoint.rotation);
                            GameObject spawned4 = Instantiate(tanky, spawnPoint.position + additive4, spawnPoint.rotation);
                            GameObject spawned5 = Instantiate(tanky, spawnPoint.position + additive1, spawnPoint.rotation);
                        }
                        else if (convTime < 2)
                        {
                            GameObject spawned = Instantiate(tanky, spawnPoint.position + additive3, spawnPoint.rotation);
                            GameObject spawned2 = Instantiate(tanky, spawnPoint.position + additive1, spawnPoint.rotation);
                            GameObject spawned3 = Instantiate(tanky, spawnPoint.position + additive2, spawnPoint.rotation);
                            GameObject spawned4 = Instantiate(tanky, spawnPoint.position + additive4, spawnPoint.rotation);

                        }
                        else if (convTime < 3)
                        {
                            GameObject spawned = Instantiate(tanky, spawnPoint.position + additive1, spawnPoint.rotation);
                            GameObject spawned2 = Instantiate(tanky, spawnPoint.position + additive4, spawnPoint.rotation);
                            GameObject spawned3 = Instantiate(tanky, spawnPoint.position + additive2, spawnPoint.rotation);
                        }
                        else
                        {
                            GameObject spawned = Instantiate(tanky, spawnPoint.position + additive1, spawnPoint.rotation);
                            GameObject spawned2 = Instantiate(tanky, spawnPoint.position + additive3, spawnPoint.rotation);
                        }
                    }
                else if (spawnNum == 4 && timeGoal <= 10800)
                {
                    if (convTime < 1)
                    {
                        GameObject spawned = Instantiate(boomy, spawnPoint.position + additive1, spawnPoint.rotation);
                        GameObject spawned2 = Instantiate(boomy, spawnPoint.position + additive2, spawnPoint.rotation);
                    }
                    else if (convTime < 2)
                    {
                        GameObject spawned = Instantiate(boomy, spawnPoint.position + additive3, spawnPoint.rotation);


                    }
                    else if (convTime < 3)
                    {
                        GameObject spawned = Instantiate(boomy, spawnPoint.position + additive1, spawnPoint.rotation);
                    }
                    else
                    {
                        GameObject spawned2 = Instantiate(boomy, spawnPoint.position + additive3, spawnPoint.rotation);
                    }
                }

            }
            

            timeDisp.text = convTime.ToString() + ":" + convSec.ToString();
            scoreDisp.text = "Score: " + score.ToString();
            if(convSec < 10)
            {
                timeDisp.text = convTime.ToString() + ":0" + convSec.ToString();
            }
        }
        else
        {
            grayOut.SetActive(true);
        }

    }
}
