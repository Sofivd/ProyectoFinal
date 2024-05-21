using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;


public class CinnamonMov : MonoBehaviour
{
    public float movX, movZ;
    Rigidbody rb;
    public float speed = 8f;
    public bool sobreSuelo = false;
    public bool saltar = false;
    public float fuerzadeSalto = 10f;
    public GameObject Slime2;
    public GameObject Transformacion;
    public GameObject CinnamonBase;
    public GameObject celda;
    private CharacterController characterController;
    private Animator animatorController;
    bool tieneLlave = false;
    bool estaPegando = false;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        animatorController = GetComponent<Animator>();
        Slime2.gameObject.SetActive(false);
        Transformacion.gameObject.SetActive(false);
        CinnamonBase.gameObject.SetActive(true);
        
    }
    void Update()
    {
        //Movimiento
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        Vector3 nuevaVelocidad = new Vector3(movX * speed, rb.velocity.y, movZ * speed);
        rb.velocity = nuevaVelocidad;

        //Rotacion
        // TOD: MIRAR LA SUMA DE LOS ANGULOS EN GRADOS PARA QUE NO PASE DE 90.
        Debug.Log(transform.rotation.ToEulerAngles().y);
        if(transform.rotation.eulerAngles.y < 90 || transform.rotation.eulerAngles.y > -90)
        {
           // transform.Rotate(new Vector3(0,movX * 45,0) * Time.deltaTime);
        }
       
        //characterController.Move(nuevaVelocidad * speed * Time.deltaTime);

        //salto
        if (Input.GetButtonDown("Jump"))
        {
            saltar = true;
            //animatorController.SetBool("EstaSaltando", true);
            animatorController.SetTrigger("Saltar");

        }
        //Ataque
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            animatorController.SetTrigger("Pegar");
            estaPegando = true;
        }


        if (saltar && sobreSuelo)
        {
            rb.AddForce(Vector3.up * fuerzadeSalto, ForceMode.Impulse);
            saltar = false;
            sobreSuelo = false;
            
        }

        animatorController.SetFloat("Velocidad",movZ );

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Suelo")
        {
            sobreSuelo = true;
           

        }
    }
    //transformacion
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Estrella")
        {
            Slime2.gameObject.SetActive(true);
            Transformacion.gameObject.SetActive(true);
            CinnamonBase.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        //Celda
        if(other.gameObject.tag == "Llave")
        {
            tieneLlave = true;
            celda.GetComponent<Celda>().Abrirse();
            Destroy(other.gameObject);
        }
        
    }
    //Animacion celda
    public void Rescate()
    {
        tieneLlave = true;
        
    }
    //Empuje Slimes
    public void Pegando()
    {
        estaPegando = true;
    }
        
}
