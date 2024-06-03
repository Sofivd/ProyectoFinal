using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;


public class CinnamonMov : MonoBehaviour
{
    Rigidbody rb;

    public float movX, movZ;
    public float speed = 8f;
    public float fuerzadeSalto = 10f;
    public float impulso = 10f;

    public bool sobreSuelo = false;
    public bool saltar = false;
    bool tieneLlave = false;
    bool estaPegando = false;
    bool Derrota;

    public GameObject Transformacion;
    public GameObject CinnamonBase;
    public GameObject celda;
    public GameObject Perdedor;

    private CharacterController characterController;
    private Animator animatorController;
   
    public int daño = 20;

    public Slider vidaMaxima;
    
    public PlayerInput Cinnamon;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animaciones
        characterController = GetComponent<CharacterController>();
        animatorController = GetComponent<Animator>();
        //transformacion y enemigo
        Transformacion.gameObject.SetActive(false);
        CinnamonBase.gameObject.SetActive(true);
        //mov
        Cinnamon = GetComponent<PlayerInput>();
    }
    void Update()
    {
        //Movimiento Input

        movInput();
        //Rotacion
        Vector2 giro = Cinnamon.actions["GIRAR"].ReadValue<Vector2>();
        transform.Rotate(new Vector3(0, giro.x, 0));
        Ascender();
        Descender();

        //Movimiento

        // movX = Input.GetAxis("Horizontal");
        // movZ = Input.GetAxis("Vertical");

        // Vector3 nuevaVelocidad = new Vector3(movX * speed, rb.velocity.y, movZ * speed);
        //  rb.velocity = nuevaVelocidad;

        //Rotacion
        // TOD: MIRAR LA SUMA DE LOS ANGULOS EN GRADOS PARA QUE NO PASE DE 90.
        // Debug.Log(transform.rotation.ToEulerAngles().y);
        // if(transform.rotation.eulerAngles.y < 90 || transform.rotation.eulerAngles.y > -90)
        //  {
        //transform.Rotate(new Vector3(0,movX * 45,0) * Time.deltaTime);
        //  }

        //characterController.Move(nuevaVelocidad * speed * Time.deltaTime);

        //salto
        //* if (Input.GetButtonDown("Jump"))
        // {
        // saltar = true;
        //animatorController.SetBool("EstaSaltando", true);
        //   animatorController.SetTrigger("Saltar");

        //  }


        //Ataque
        // if (Input.GetKeyDown(KeyCode.E)) 
        {
         //   animatorController.SetTrigger("Pegar");
          //  estaPegando = true;
        }


        if (saltar && sobreSuelo)
        {
            rb.AddForce(Vector3.up * fuerzadeSalto, ForceMode.Impulse);
            saltar = false;
            sobreSuelo = false;
            
        }

        animatorController.SetFloat("Velocidad",movZ );

        //Vida
        vidaMaxima.GetComponent<Slider>().value = daño;
        if(vidaMaxima.GetComponent<Slider>().value == 0)
        {
            Derrota = true;
            Time.timeScale = 0;
        }
    }
    //Movimiento InputSystem
    public void movInput()
    {
        Vector2 mov = Cinnamon.actions["Movimiento"].ReadValue<Vector2>();
        // mov = (1,0);
        movX = mov.x;
        movZ = mov.y;
        Vector3 haciaAdelante = mov.y * speed * transform.forward;
        Vector3 deLado = mov.x * speed * transform.right;
        Vector3 movimiento = haciaAdelante + deLado;
        movimiento.y = rb.velocity.y;
        rb.velocity = movimiento;
    }
    //Salto
    public void Saltar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && sobreSuelo == true)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            animatorController.SetTrigger("Saltar");
            sobreSuelo = false;
        }
        Debug.Log("Saltando : Estoy en fase " + context.phase);
    }

    public void Ascender()
    {
        if (Cinnamon.actions["ASCENDER"].IsPressed())
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            //Vector3 Palante = new Vector3(movX * speed, impulso, movZ * speed);
            // rb.velocity = Palante;
            Debug.Log("Subiendo");
        }

    }
    public void Descender()
    {
        if (Cinnamon.actions["DESCENDER"].IsPressed())
        {
            rb.AddForce(-Vector3.up * 10, ForceMode.Impulse);
        }
    }
    //Ataque
    public void Pegar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            animatorController.SetTrigger("Pegar");
            estaPegando = true;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Suelo")
        {
            sobreSuelo = true;
        }
         //Daño enemigos
        if(collision.gameObject.tag == "Enemigo")
        {
            daño = daño - 5;
            Debug.Log("Te han hecho daño");
        }
        //Plataforma de pinchos
        if(collision.gameObject.tag == "Pinchos")
        {
            daño = daño - 5;
            Debug.Log("Te han hecho daño");
        }
        if(collision.gameObject.tag == "Mar")
        {
            Derrota = true;
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //transformacion
        if (other.gameObject.tag == "Estrella")
        {
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
