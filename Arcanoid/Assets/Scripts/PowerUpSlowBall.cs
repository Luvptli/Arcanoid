using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlowBall : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SlowBall();
        }
        if (other.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }

    public void SlowBall()
    {
        MovimientoPelota.instance.pelotaRb.velocity *= 0.5f ;
    }
}
