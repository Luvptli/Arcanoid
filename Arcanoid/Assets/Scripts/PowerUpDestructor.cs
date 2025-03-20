using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDestructor : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RomperBloques.instance.destructor=true;
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }
}
