using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public string sceneName;
    public static int takenScore;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
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
