using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVida : MonoBehaviour
{
    [SerializeField]
    MovimientoPelota movimientoPelota;
    void Start()
    {
        movimientoPelota = FindObjectOfType<MovimientoPelota>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Vida();
        }
        if (collision.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }
    public void Vida()
    {
        movimientoPelota.vidas += 1;
        movimientoPelota.vidaLabel.text = movimientoPelota.vidas.ToString();
    }

}
