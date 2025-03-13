using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInverse : MonoBehaviour
{
    [SerializeField]
    MovimientoJugador movimientoJugador;

    [SerializeField]
    float timeInverse = 10f;

    void Start()
    {
        movimientoJugador = FindObjectOfType<MovimientoJugador>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            InverseControll();
        }
        if (collision.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }

    //revisar que funcione

    private IEnumerator InverseControll()
    {
        movimientoJugador.movimientoRevertido = true; 
        yield return new WaitForSeconds(timeInverse); 
        movimientoJugador.movimientoRevertido = false;
    }
}
