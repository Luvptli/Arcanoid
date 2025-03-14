using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInverse : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MovimientoJugador.instance.InverseControll());
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }
   
}
