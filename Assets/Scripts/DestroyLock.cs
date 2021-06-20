using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLock : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Lock")
        {
            Destroy(gameObject);
        }
    }
}
