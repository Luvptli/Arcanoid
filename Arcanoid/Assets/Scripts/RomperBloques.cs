using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RomperBloques : MonoBehaviour
{
    public static RomperBloques instance;

    public int vidaBloq = 2;
    public int vidaSave = 2;
    public List<GameObject> powerUps;
    public float probPUMax = 0.3f;
    public float probPUMin = 0.2f;
    public float valor;
    public ScoreBehaviour scoreBehaviour;

    public bool destructor;
    public float timeInverse = 10f;

    public AudioClip brokenWall;
    private AudioSource audioSource;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreBehaviour = ScoreBehaviour.instance;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 1.0f;
    }
    private void Update()
    {
        if (destructor ==true)
        {
            StartCoroutine(DestructionPower());
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (destructor == true)
        {
            vidaBloq -=4;
        }
        else
        {
            vidaBloq --;
        }
        
        if (vidaBloq <= 0)
        {
            InstantiatePowerUp();
            audioSource.PlayOneShot(brokenWall);
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

    public IEnumerator DestructionPower()
    {
        destructor = true;
        
        yield return new WaitForSeconds(timeInverse);
        destructor = false;

        yield return null;
    }
}




    






