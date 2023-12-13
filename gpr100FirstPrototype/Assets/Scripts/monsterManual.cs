using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monsterManual : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SwitchScene();
        }
        else if(Input.GetKeyUp(KeyCode.Escape))
        {
            SwitchScene();
        }
    }
    public void SwitchScene()
    {
        /*int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = 0;
        if(currentSceneIndex +1 < SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = currentSceneIndex +1;
        }
        SceneManager.LoadScene(nextSceneIndex);
        this is useless, it would only progress one scene forwards rather than change to the specified scene
        which will allow the end scene to go back to the start*/
        SceneManager.LoadScene(sceneName);
    }
}
