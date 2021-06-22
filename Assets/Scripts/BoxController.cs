using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    public float distance;
    public Animation animationMoney;
    public Animation animationMed;

    public Text textHealth;
    public Text textCoin;
    public Text textCoins;

    int coins;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
            {
                Box box = hit.collider.GetComponent<Box>();

                if (hit.collider.tag == "BoxMoney" && box.isOpen == false)
                {
                    animationMoney = hit.collider.GetComponent<Animation>();
                    animationMoney.Play();
                    box.isOpen = true;

                    Collider collider = hit.collider.GetComponent<Collider>();
                    Destroy(collider);
                }

                if (hit.collider.tag == "BoxMed" && box.isOpen == false)
                {
                    animationMed = hit.collider.GetComponent<Animation>();
                    animationMed.Play();
                    box.isOpen = true;

                    Collider collider = hit.collider.GetComponent<Collider>();
                    Destroy(collider);
                }

                if (hit.collider.tag == "Aid")
                {
                    Destroy(hit.collider.gameObject);
                    StartCoroutine(WaitHealth());
                }

                if (hit.collider.tag == "Coins")
                {
                    Destroy(hit.collider.gameObject);
                    StartCoroutine(WaitCoin());
                }
            }
        }
    }

    IEnumerator WaitHealth()
    {
        CharacterControll health = GetComponent<CharacterControll>();
        int add = Random.Range(5, 20);

        if ((health.healthBar.maxValue - health.currentHealthPlayer) > add)
        {
            health.currentHealthPlayer += add;
        }

        else
        {
            add = Mathf.RoundToInt(health.healthBar.maxValue - health.currentHealthPlayer);
            health.currentHealthPlayer = health.healthBar.maxValue;
        }

        textHealth.text = $"+{add}";
        health.healthBar.value = health.currentHealthPlayer;
        health.DamagePlayer(-add);

        yield return new WaitForSeconds(2);
        textHealth.text = "";
    }

    IEnumerator WaitCoin()
    {
        int add = Random.Range(20, 60);
        coins += add;
        textCoin.text = $"+{add}";
        textCoins.text = coins.ToString();

        yield return new WaitForSeconds(2);
        textCoin.text = "";
    }
}
