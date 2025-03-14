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
        movimientoPelota.vidas += 1;
        movimientoPelota.vidaLabel.text = movimientoPelota.vidas.ToString();
    }

}
