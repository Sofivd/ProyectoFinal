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
    public int daño = 20;
    public Slider vidaMaxima;
    public GameObject Perdedor;
    bool Derrota;
    public PlayerInput Cinnamon;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animaciones
        characterController = GetComponent<CharacterController>();
        animatorController = GetComponent<Animator>();
        //transformacion y enemigo
        Slime2.gameObject.SetActive(false);
        Transformacion.gameObject.SetActive(false);
        CinnamonBase.gameObject.SetActive(true);
        //mov
        Cinnamon = GetComponent<PlayerInput>();
    }
    void Update()
    {
        //Movimiento Input

        movInput();

        Vector2 giro = Cinnamon.actions["GIRAR"].ReadValue<Vector2>();
        transform.Rotate(new Vector3(0, giro.x, 0));

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
    public void Saltar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            animatorController.SetTrigger("Saltar");
        }
        Debug.Log("Saltando : Estoy en fase " + context.phase);
    }
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
         //daño enemigos
        if(collision.gameObject.tag == "Enemigo")
        {
            daño = daño - 5;
            Debug.Log("Te han hecho daño");
        }
        if(collision.gameObject.tag == "Pinchos")
        {
            daño = daño - 5;
            Debug.Log("Te han hecho daño");
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
