using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScore : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ExtraScore();
        }
        if (other.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }

    public void ExtraScore()
    {
        //sumar 5000 puntos al score total, arreglar primero el funcionamiento de los puntos cuando rompa bloques
    }
}
