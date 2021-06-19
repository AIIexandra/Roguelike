using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float distance;
    public Room room;

    void Start()
    {
        GameObject r = GameObject.Find("Room");
        room = r.GetComponent<Room>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {           
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
            {
                if (hit.collider.tag == "Door" && room.isClean == true)
                {
                    Door door = hit.collider.GetComponent<Door>();
                    door.isOpen = !door.isOpen;
                }
            }
        }
    }
}
