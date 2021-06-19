using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isClean = false;
    public Door door;

    void Start()
    {
        GameObject d = GameObject.Find("Door");
        door = d.GetComponent<Door>();
    }


    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy") isClean = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") door.CloseDoors();
    }
}
