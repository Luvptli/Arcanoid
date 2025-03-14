using UnityEngine;

public class PowerUpSlowBall : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SlowBall();
            StartCoroutine(MovimientoPelota.instance.SlowBallCoroutine());
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }
    public void SlowBall()
    {
        MovimientoPelota.instance.slowBallTrue = true;
    }
}
