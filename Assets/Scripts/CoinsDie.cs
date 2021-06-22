using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsDie : MonoBehaviour
{
    //public Text textCoin;
    int coins;
    int prefsCoins;
    BoxController box;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        box = player.GetComponent<BoxController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(WaitCoin());

        }
    }

    IEnumerator WaitCoin()
    {
        int add = Random.Range(20, 60);
        prefsCoins = PlayerPrefs.GetInt("coins");
        prefsCoins += add;
        box.textCoin.text = $"+{add}";
        PlayerPrefs.SetInt("coins", prefsCoins);

        Destroy(gameObject.GetComponent<Collider>());
        Destroy(gameObject.GetComponent<MeshRenderer>());

        yield return new WaitForSecondsRealtime(2);
        box.textCoin.text = "";
        Destroy(gameObject);
    }
}
