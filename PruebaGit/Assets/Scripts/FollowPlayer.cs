using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform jugadorObjetivo;
    private float speed = 4;
    Vector3 posicionJugador;

    void Start()
    {

    }

    void Update()
    {
        if (jugadorObjetivo != null)
        {
            posicionJugador = new Vector3(jugadorObjetivo.position.x, jugadorObjetivo.position.y, jugadorObjetivo.position.z);
            transform.position = Vector3.MoveTowards(transform.position, posicionJugador, speed * Time.deltaTime); 
            //porqué sin Time.deltaTime aparece automáticamente pegado al jugador?
        }
        
    }
}
