 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void LoadNextScene()
    {
        int currenSceneIdex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currenSceneIdex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
