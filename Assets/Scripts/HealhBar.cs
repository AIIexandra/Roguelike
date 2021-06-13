using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealhBar : MonoBehaviour
{
    public Slider healthBar;

    void Start()
    {

    }


    void Update()
    {
        
    }

    public void SetHealthValue(float currentHealth, float maxHealth)
    {
        healthBar.gameObject.SetActive(currentHealth < maxHealth);
        healthBar.value = currentHealth;
        healthBar.maxValue = maxHealth;
    }
}
