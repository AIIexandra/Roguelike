using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BadGuy : MonoBehaviour
{
    [Header("Health")]
    public float currentHealth = 50;  //здоровье
    public float maxHealth = 50;

    [Header("Follow")]
    GameObject player;
    public float distance;
    NavMeshAgent nav;
    public float radius = 15;    //радиус обзора врагов

    [Header("Health bar")]
    public Slider slider;  //эталонный слайдер
    Slider sliderHealth;   //создаваемый слайдер
    public Canvas canvasHealthBar;   //родитель для слайдера
    public Vector3 offset; //смещение для слайдера

    public GameObject coins;

    void Start()
    {
        player = GameObject.Find("Player");

        nav = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;

        sliderHealth = Instantiate(slider);   //создать слайдер
        sliderHealth.transform.SetParent(canvasHealthBar.transform, true);   //прикрепить слайдер к канвасу
        sliderHealth.transform.position = canvasHealthBar.transform.position + offset;  //сместить слайдер
        sliderHealth.transform.rotation = canvasHealthBar.transform.rotation;
        sliderHealth.maxValue = maxHealth;
        sliderHealth.value = maxHealth;
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
        sliderHealth.value = currentHealth;

        if(currentHealth <= 0)
        {
            Instantiate(coins, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
