using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class MovimientoJugador : MonoBehaviour
{
    public static MovimientoJugador instance;

    [SerializeField]
    public float speed = 7f;
    [SerializeField]
    public float minX = 132f; 
    [SerializeField]
    public float maxX = 980f;

    private Rigidbody2D paloRb;

    [SerializeField]
    public float minZ = -1.3f;
    [SerializeField]
    public float maxZ = 7.7f;

    [SerializeField]
    Vector3 posInicial;

    public bool movimientoRevertido;
    public float timeInverse = 10f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        posInicial = transform.position;
        movimientoRevertido = false;
    }

    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        float partida = Input.GetAxisRaw("Vertical");

        if (movimientoRevertido)
        {
            movement *= -1;
            partida *= -1;
            StartCoroutine(InverseControll());
        }

        float newPosX = transform.position.x + movement * speed * Time.deltaTime;
        float newPosZ = transform.position.z + partida * speed * Time.deltaTime;

        newPosX = Mathf.Clamp(newPosX, minX, maxX);
        newPosZ = Mathf.Clamp(newPosZ, minZ, maxZ);

        transform.position = new Vector3(newPosX, transform.position.y, newPosZ);
    }

    public void ResetPlayer()
    {
        transform.position = posInicial;
    }

    public IEnumerator InverseControll()
    {
        movimientoRevertido = true;
        yield return new WaitForSeconds(timeInverse);
        movimientoRevertido = false;
        yield return null;
    }
}

