using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float angleOpenDoor;
    [SerializeField] float angleCloseDoor;
    [SerializeField] float speed;
    public bool isOpen;

    void FixedUpdate()
    {
        if (isOpen) OpenDoors();
        else CloseDoors();    
    }

    void OpenDoors()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 0, angleOpenDoor), speed * Time.deltaTime);
    }

    public void CloseDoors()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 0, angleCloseDoor), speed * Time.deltaTime);
    }
}
