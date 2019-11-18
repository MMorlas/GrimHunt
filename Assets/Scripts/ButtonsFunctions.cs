using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    /*
    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene(1);
    }
    */
    public void LoadScene(int sceneIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
    }
}
