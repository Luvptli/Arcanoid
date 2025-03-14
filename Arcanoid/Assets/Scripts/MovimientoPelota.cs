using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using TMPro.EditorUtilities;
using UnityEditor;

public class MovimientoPelota : MonoBehaviour
{
    public static MovimientoPelota instance;

    [SerializeField]
    TextMeshProUGUI timeLabel;
    [SerializeField]
    TextMeshProUGUI timeLabel2;
    [SerializeField]
    TextMeshProUGUI timeLabel3;
    [SerializeField]
    public float tiempoPartida;

    [SerializeField]
    public Rigidbody pelotaRb;

    [SerializeField]
    public Vector3 velPelota;
    

    public bool juegoEmpezo;

    [SerializeField]
    GameObject pantallaP;

    
    public float vidas = 3;
    public TextMeshProUGUI vidaLabel;

    [SerializeField]
    Vector3 posInicial;

    [SerializeField]
    GameObject canvasJuego;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        pelotaRb= GetComponent<Rigidbody>();
        posInicial = transform.position;
        transform.parent = FindObjectOfType<MovimientoJugador>().transform;
    }
    void Update()
    {
        float minutos = Mathf.FloorToInt(tiempoPartida / 60F);
        float segundos = Mathf.FloorToInt(tiempoPartida % 60F);
        float milesimas = Mathf.FloorToInt((tiempoPartida * 60) % 60F);

        if (juegoEmpezo)
        {
            tiempoPartida += Time.deltaTime;
            timeLabel.text = tiempoPartida.ToString();
            timeLabel2.text = tiempoPartida.ToString();
            timeLabel3.text = tiempoPartida.ToString();
            timeLabel.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milesimas);
            timeLabel2.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milesimas);
            timeLabel3.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milesimas);
            transform.parent = null;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                juegoEmpezo = true;
                pelotaRb.velocity = velPelota;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Muro"))
        {
            if (vidas > 0)
            {
                vidas--;
                vidaLabel.text = vidas.ToString();
                juegoEmpezo = false;
                FindObjectOfType<MovimientoJugador>().ResetPlayer();
                gameObject.transform.parent = FindObjectOfType<MovimientoJugador>().transform;
                transform.position = posInicial;
                juegoEmpezo = false;
                pelotaRb.velocity=Vector3.zero;
            }
            else if (vidas == 0)
            {
                pantallaP.SetActive(true);
                canvasJuego.SetActive(false);
                juegoEmpezo = false;
            }
        }
    }
}
