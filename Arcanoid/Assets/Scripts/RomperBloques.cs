using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BloquesRomper : MonoBehaviour
{
    public int vidaBloq = 2;
    public int totalBloq = 16;

    [SerializeField]
    GameObject pantallaG;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {





    }

   private void OnCollisionEnter(Collision other)
    {
        vidaBloq--;

        if (vidaBloq == 0)
        {
            
            Destroy(gameObject);
            totalBloq--;
            if (totalBloq <= 0)
            {
                pantallaG.SetActive(true);
            }

        }
            
   }
}




    





