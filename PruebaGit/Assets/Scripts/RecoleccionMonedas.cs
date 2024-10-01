using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoleccionMonedas : MonoBehaviour
{
    //public GameObject contenedor;
    public Text textos;
    public int contador = 0;

    private void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            contador = 0;
            textos.text = "Monedas: " + contador;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Moneda")
        {
            //Debug.Log("colisiona");
            sumarPunto();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        } else if(other.gameObject.tag == "Enemigo")
        {
            contador = 0;
            textos.text = "Monedas: " + contador;
        }
    }

    private void sumarPunto()
    {
        contador++;
        textos.text = "Monedas: " + contador.ToString();
        //Debug.Log(textos.text);
    }

}
