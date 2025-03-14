using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDestructor : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destruction();
        }
        if (other.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }

    public void Destruction()
    {
        //la vida de los bloques deberá ser solo 1 o que la pelota quite 4 de vida
    }
}
