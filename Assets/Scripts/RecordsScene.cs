using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordsScene : MonoBehaviour
{

    void Start()
    {
        Debug.Log("Scene1 is load");
    }

    void Update()
    {
        
    }

    public void OnMainMenu()
    {
        Debug.Log("Scene2 is load");
        SceneManager.LoadSceneAsync(0);
    }
}
