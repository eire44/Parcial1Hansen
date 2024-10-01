using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller_Player : MonoBehaviour
{
    public float speed = 5;
    public GameObject enemigo;

    private Rigidbody rb;
    private Vector3 posicionInicial;
    private Vector3 posicionInicialEnemigo;

    //public GameObject projectile;
    //public GameObject doubleProjectile;
    //public GameObject missileProjectile;
    //public GameObject laserProjectile;
    //public GameObject option;
    //public int powerUpCount=0;

    //internal bool doubleShoot;
    //internal bool missiles;
    //internal float missileCount;
    //internal float shootingCount=0;
    //internal bool forceField;
    //internal bool laserOn;

    //public static bool lastKeyUp;

    //public delegate void Shooting();
    //public event Shooting OnShooting;

    //private Renderer render;

    //internal GameObject laser;

    //private List<Controller_Option> options;

    //public static Controller_Player _Player;
    public GameObject ubicacionBala;
    public GameObject balaPrefab;
    public float velocidadBala;

    private void Awake()
    {
        //if (_Player == null)
        //{
        //    _Player = GameObject.FindObjectOfType<Controller_Player>();
        //    if (_Player == null)
        //    {
        //        GameObject container = new GameObject("Player");
        //        _Player = container.AddComponent<Controller_Player>();
        //    }
        //    //Debug.Log("Player==null");
        //    //DontDestroyOnLoad(_Player);
        //}
        //else
        //{
        //    //Debug.Log("Player=!null");
        //    //this.gameObject.SetActive(false);
        //    //Destroy(this.gameObject);
        //}
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //render = GetComponent<Renderer>();
        //powerUpCount = 0;
        //doubleShoot = false;
        //missiles = false;
        //laserOn = false;
        //forceField = false;
        //options = new List<Controller_Option>();



        
        posicionInicial = transform.position; //porque el transform no existe fuera del método?
        posicionInicialEnemigo = enemigo.transform.position;
    }

    private void Update()
    {
        //CheckForceField();
        //ActionInput();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            balaPrefab.SetActive(true);
            GameObject Bala2 = Instantiate(balaPrefab, transform.position, transform.rotation) as GameObject;
            //Debug.Log("nueva bala");
            Bala2.tag = "Bala";
            Rigidbody rb = Bala2.GetComponent<Rigidbody>();

            rb.AddForce(ubicacionBala.transform.right * velocidadBala);

            balaPrefab.SetActive(false);
        }
    }

    private void CheckForceField()
    {
        //if (forceField)
        //{
        //    render.material.color = Color.blue;
        //}
        //else
        //{
        //    render.material.color = Color.red;
        //}
    }

    public virtual void FixedUpdate()
    {
        Movement();
    }

    public virtual void ActionInput()
    {
        //missileCount -= Time.deltaTime;
        //shootingCount -= Time.deltaTime;
        //if (Input.GetKey(KeyCode.O) && shootingCount < 0)
        //{
        //    if (OnShooting != null)
        //    {
        //        OnShooting();
        //    }


        //    Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);


        //    shootingCount = 0.1f;
        //}
    }


    private void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(speed* inputX, 0.0f, speed * inputY);
        rb.velocity = movement;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    lastKeyUp = true;
        //}else
        //if (Input.GetKey(KeyCode.S))
        //{
        //    lastKeyUp = false;
        //}
        if (Input.GetKey(KeyCode.R))
        {
            reiniciarEscena();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Potenciador")
        {
            
            Destroy(other.gameObject);
            speed = speed * 2;
        }
        else if(other.gameObject.tag == "Enemigo")
        {
            reiniciarEscena();
        }
    }

    private void reiniciarEscena()
    {
        transform.position = posicionInicial;
        speed = 5;
        enemigo.transform.position = posicionInicialEnemigo;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
