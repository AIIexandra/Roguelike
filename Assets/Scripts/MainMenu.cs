using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OnRecordsScene()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
