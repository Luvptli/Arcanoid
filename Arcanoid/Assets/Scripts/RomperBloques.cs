using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RomperBloques : MonoBehaviour
{
    public int vidaBloq = 2;
    public List<GameObject> powerUps;
    public float probPUMax = 0.3f;
    public float probPUMin = 0.2f;
    public float valor;
    public ScoreBehaviour scoreBehaviour;

    void Start()
    {
        scoreBehaviour = ScoreBehaviour.instance;
    }
    private void OnCollisionEnter(Collision other)
    {
        vidaBloq--;
        if (vidaBloq == 0)
        {
            InstantiatePowerUp();
            Destroy(gameObject);
            FindObjectOfType<Bloques>().Restar();
            scoreBehaviour.Score(valor);
        }
   }

    void InstantiatePowerUp()
    {
        if (Random.value <= probPUMax || Random.value >=probPUMin)
        {
            int numPU = Random.Range(0, powerUps.Count); 
            Instantiate(powerUps[numPU], transform.position, Quaternion.identity);
        }
    }
}




    






