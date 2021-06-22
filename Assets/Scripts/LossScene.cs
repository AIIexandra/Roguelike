using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LossScene : MonoBehaviour
{
    public Text coins;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        coins.text = PlayerPrefs.GetInt("coins").ToString();
        if(PlayerPrefs.GetInt("coins") > PlayerPrefs.GetInt("recordCoins"))
        {
            PlayerPrefs.SetInt("recordCoins", PlayerPrefs.GetInt("coins"));
        }
    }
}
