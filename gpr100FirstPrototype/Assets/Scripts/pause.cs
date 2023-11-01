using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public bool isPause = false;
    public string nextScene;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(isPause == false)
            {
                Time.timeScale = 0;
                isPause = true;
            }
            else if(isPause == true)
            {
                Time.timeScale = 1;
                isPause = false;
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
