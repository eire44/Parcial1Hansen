using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    int contadorVidas;
    // Start is called before the first frame update
    void Start()
    {
        contadorVidas = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bala")
        {
            contadorVidas++;
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            if(contadorVidas == 3)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
