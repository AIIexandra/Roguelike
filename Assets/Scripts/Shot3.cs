using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot3 : MonoBehaviour
{

    public float damage = 25f;     //урон от выстрела
    public float fireRate = 0.25f; //время между выстрелами
    float nextFire;                //игровое время
    public float distance = 15;    //дальность выстрела

    public Transform spawnLaser;
    Camera cam;
    WaitForSeconds laserDuration = new WaitForSeconds(0.05f);  //время отрисовки лазера
    public AudioSource shotSound;  //звук выстрела
    LineRenderer laserLine;

    public GameObject hitEffect;   //эффект после выстрела
    public GameObject explosionEffect;   //эффект после убийства

    void Start()
    {
        shotSound = GetComponent<AudioSource>();
        cam = GetComponentInChildren<Camera>();
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            laserLine.SetPosition(0, spawnLaser.transform.position);

            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, distance))
            {
                laserLine.SetPosition(1, hit.point);
                BadGuy health = hit.collider.GetComponent<BadGuy>();

                if (health != null) 
                {
                    health.Damage(damage);

                    GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impact, 1f);

                    if (health.currentHealth <= 0)
                    {
                        impact = Instantiate(explosionEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(impact, 1f);
                    }
                }
            }

            else
            {
                laserLine.SetPosition(1, cam.transform.forward * distance);
            }
        }
    }

    IEnumerator ShotEffect()
    {
        shotSound.Play();
        laserLine.enabled = true;
        yield return laserDuration;
        laserLine.enabled = false;
    }
}
