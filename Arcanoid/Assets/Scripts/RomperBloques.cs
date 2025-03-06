using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RomperBloques : MonoBehaviour
{
    public int vidaBloq = 2;

    private void OnCollisionEnter(Collision other)
    {
        vidaBloq--;

        if (vidaBloq == 0)
        {
            Destroy(gameObject);
            FindObjectOfType<ScreenScript>().canvasPowerUp.SetActive(true);
            FindObjectOfType<Bloques>().Restar();
            Debug.Log("Restando");
        }
            
   }
}




    






