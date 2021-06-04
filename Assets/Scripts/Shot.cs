using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform bullet;
    public int bulletForse = 5000;
    //public int magazine = 100;
    public AudioClip shot;



    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform bulletInstance = (Transform)Instantiate(bullet, GameObject.Find("SpawnBullet").transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForse);
            GetComponent<AudioSource>().PlayOneShot(shot);
        }
    }
}
