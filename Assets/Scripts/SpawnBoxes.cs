using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{

    public GameObject[] boxTypes;
    public Transform spawn;

    [Range(0, 1)]
    public float chance = 0.2f;

    public bool spawned = false;
    int i = 0;

    private void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        i++;
        double rand = Random.value;

        if (other.tag == "Lock" && rand <= chance && spawned == false && i >= 6)
        {
            GameObject boxType = boxTypes[Random.Range(0, boxTypes.Length)];
            Instantiate(boxType, spawn.position, spawn.rotation);
            Destroy(gameObject);
            spawned = true;
        }

        if (i >= 6)
        {
            spawned = true;
            Destroy(gameObject);
        }
    }
}
