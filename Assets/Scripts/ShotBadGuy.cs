using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotBadGuy : MonoBehaviour
{
    public float damage = 10f;       //урон от выстрела
    public float fireRate = 3f;      //время между выстрелами
    float nextFire;                  //игровое время
    public float distance = 100;     //дальность выстрела

    public Transform spawnLaser;
    WaitForSeconds laserDuration = new WaitForSeconds(0.1f);  //время отрисовки лазера
    LineRenderer laserLine;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }


    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            //Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            laserLine.SetPosition(0, spawnLaser.transform.position);

            if (Physics.Raycast(spawnLaser.transform.position, spawnLaser.transform.forward, out hit, distance))
            {
                laserLine.SetPosition(1, hit.point);
                CharacterControll health = hit.collider.GetComponent<CharacterControll>();

                if (health != null)
                {
                    health.DamagePlayer(damage);
                    Debug.Log("Попал");
                    
                    if (health.currentHealthPlayer <= 0)
                    {
                       //die
                    }
                }
            }

            else
            {
                laserLine.SetPosition(1, gameObject.transform.forward * distance);
            }
        }
    }

    IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return laserDuration;
        laserLine.enabled = false;
    }
}
