using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class pause : MonoBehaviour
{
    public bool isPause = false;
    public string nextScene;
    public TextMeshProUGUI pauseMessage;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(isPause == false)
            {
                Time.timeScale = 0;
                isPause = true;
                pauseMessage.text = "Game is Paused";
            }
            else if(isPause == true)
            {
                Time.timeScale = 1;
                isPause = false;
                pauseMessage.text = "";
            }
            
        }
    }
    public bool getPause()
    {
        return isPause;
    }
    public void changeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
