using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordsScene : MonoBehaviour
{
    public void OnMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
