using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVida : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Vida();
        }
        if (other.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }
    public void Vida()
    {
        MovimientoPelota.instance.vidas ++;
        MovimientoPelota.instance.vidaLabel.text = MovimientoPelota.instance.vidas.ToString();
    }

}
