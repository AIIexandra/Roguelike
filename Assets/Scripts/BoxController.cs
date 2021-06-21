using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float distance;
    public Animation animationMoney;
    public Animation animationMed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
            {
                if (hit.collider.tag == "BoxMoney")
                {
                    animationMoney = hit.collider.GetComponent<Animation>();
                    animationMoney.Play();
                }

                if (hit.collider.tag == "BoxMed")
                {
                    animationMed = hit.collider.GetComponent<Animation>();
                    animationMed.Play();
                }
            }
        }
    }
}
