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
    public Transform spawnPoint;
    public PlayerHealth healthCheck;
    public TextMeshProUGUI healthDisp;
    private float tempHealth;
    // Start is called before the first frame update
    void Start()
    {

        QualitySettings.vSyncCount = 0;  // this disables vsync so I can set the frame rate to limit the timer
        Application.targetFrameRate = 60; // hoepfully limit the frame rate
    }

    // Update is called once per frame
    void Update()
    {
        int xRand = Random.Range(10, 30);
        int yRand = Random.Range(10, 30);
        int negXRand = Random.Range(-10, -30);
        int negYRand = Random.Range(-10, -30);
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
            tempHealth = healthCheck.getHealth() / 2;
            healthDisp.text = tempHealth.ToString();
            timeGoal--;
            if (timeGoal <= 0)
            {
                timerEnd.changeScene();
            }
            convTime = (timeGoal / 60) / 60;
            convSec = (timeGoal / 60) % 60;
            if(timeGoal % 60 == 0)
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
            

            timeDisp.text = convTime.ToString() + ":" + convSec.ToString();
            if(convSec < 10)
            {
                timeDisp.text = convTime.ToString() + ":0" + convSec.ToString();
            }
        }

    }
}
