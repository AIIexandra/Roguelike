using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{

    public float currentHealth = 50;

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
