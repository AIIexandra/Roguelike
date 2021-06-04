using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot2 : MonoBehaviour
{
    public ParticleSystem shotEffect;    //эффект на дуле
    public GameObject hitEffect;         //эфеект после выстрела
    public float distance = 15;          //дальность выстрела
    public GameObject spawn;             //место, откуда RaycastHit
    public Transform spawnBullet;        //место, откуда пули
    public AudioSource shotSoundSource;  //звук выстрела
    public AudioClip shotSoundClip;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        shotSoundSource.PlayOneShot(shotSoundClip);
        //Instantiate(shotEffect, spawnBullet.position, spawnBullet.rotation);
        //shotEffect.Play();

        RaycastHit hit;

        if(Physics.Raycast(spawn.transform.position, spawn.transform.forward, out hit, distance))
        {
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);

            if (hit.rigidbody != null)
            {

            }
        }
    }
}
