using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isClean = true;
    public Door door;
    public Door[] doors; 

    void Start()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Door");

        for (int i = 0; i < doors.Length; i++)
            doors[i] = go[i + ((int.Parse(gameObject.name) - 1) * 4)].GetComponent<Door>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy") isClean = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isClean == false)
            for (int i = 0; i < doors.Length; i++)
                doors[i].isOpen = false;
    }
}
