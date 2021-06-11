using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadGuy : MonoBehaviour
{
    public float currentHealth = 50;  //здоровье

    public GameObject player;
    public float distance;
    NavMeshAgent nav;
    public float radius = 15;    //радиус обзора врагов
    //public ParticleSystem explosionEffect;
    //public GameObject explosionEffect;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance > radius)
        {
            nav.enabled = false;
        }

        else
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
        }
    }
    
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            //gameObject.SetActive(false);
            //GameObject impact = Instantiate(explosionEffect, explosionEffect.transform.position, Quaternion.identity);
            //Destroy(impact, 1f);

            Destroy(gameObject);
            //explosionEffect.Play();
        }
    }
}
