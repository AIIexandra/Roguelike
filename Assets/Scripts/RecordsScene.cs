using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecordsScene : MonoBehaviour
{
    public Text record;

    private void Start()
    {
        record.text = PlayerPrefs.GetInt("recordCoins").ToString();
    }

    public void OnMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
