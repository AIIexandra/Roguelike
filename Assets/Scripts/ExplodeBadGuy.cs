using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodeBadGuy : MonoBehaviour
{
    public float damage = 10;   //урон от взрыва
    public float explosionTime = 5;   //время до взрыва
    public Slider explosionBar;
    public AudioSource explosionHit;  //звук взрыва
    public GameObject explosionEffect;  //взрыв
    public Transform explosionSpawn;
    BadGuy badGuy;
    GameObject player;
    CharacterControll character;

    void Start()
    {
        badGuy = GetComponent<BadGuy>();
        explosionBar.maxValue = explosionTime;
        player = GameObject.Find("Player");
        character = player.GetComponent<CharacterControll>();
    }


    void Update()
    {
        if(badGuy.distance <= 3)
        {
            if (explosionTime >= 0) 
            {
                //StartCoroutine(ExplosionBar());
                explosionTime -= Time.deltaTime;
                explosionBar.value = explosionTime;
            }

            else
            {
                character.DamagePlayer((1 / badGuy.distance) * damage);
                Instantiate(explosionEffect, explosionSpawn.position, Quaternion.identity);
                Destroy(gameObject);
            }            
        }
    }

    IEnumerator ExplosionBar()
    {
        explosionTime -= 1f;
        explosionBar.value = explosionTime;
        yield return new WaitForSeconds(1f);
    }
}
