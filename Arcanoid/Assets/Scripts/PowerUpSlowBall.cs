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
        //jugar con el rb del script movimiento pelota que sea  * 0,5 durante cierto tiempo y dp vuelva a la normalidad
    }
}
