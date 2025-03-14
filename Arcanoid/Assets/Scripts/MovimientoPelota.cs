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
    Rigidbody pelotaRb;

    [SerializeField]
    Vector3 velPelota;
    [SerializeField]
    Vector3 velOrigPelota;

    public bool juegoEmpezo;

    [SerializeField]
    GameObject pantallaP;

    
    public float vidas = 3;
    public TextMeshProUGUI vidaLabel;

    [SerializeField]
    Vector3 posInicial;

    [SerializeField]
    GameObject canvasJuego;

    public bool slowBallTrue;
    public float timeInverse = 10f;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        pelotaRb= GetComponent<Rigidbody>();
        posInicial = transform.position;
        transform.parent = FindObjectOfType<MovimientoJugador>().transform;
        slowBallTrue = false;
        velOrigPelota = pelotaRb.velocity;
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
                if (slowBallTrue ==true)
                {
                    StartCoroutine(SlowBallCoroutine());
                }
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
    public IEnumerator SlowBallCoroutine()
    {
        slowBallTrue = true;
        pelotaRb.velocity/=2f;
        yield return new WaitForSeconds(timeInverse);
        slowBallTrue = false;
        pelotaRb.velocity = velOrigPelota;
        yield return null;
    }
}
