using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScore : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ExtraScore();
        }
        if (collision.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }

    public void ExtraScore()
    {
        //sumar 5000 puntos al score total, arreglar primero el funcionamiento de los puntos cuando rompa bloques
    }
}
