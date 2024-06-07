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

    bool Derrota;
    bool tieneLlave = false;
    bool estaPegando = false;
    
    public bool sobreSuelo = false;
    public bool saltar = false;
    public bool fullVida = true;
    public bool mediaVida = false;
    public bool unaVida = false;
    public bool sinVida = false;
    public bool angelActivado = false;
    public bool zonaEstrella = false;
    

    public GameObject Transformacion;
    public GameObject CinnamonBase;
    public GameObject celda;
    public GameObject Perdedor;
    public GameObject tresCorazones;
    public GameObject dosCorazones;
    public GameObject unCorazon;
    public GameObject sinVidas;
    public GameObject iconoCabeza;
    public GameObject iconoCabezaAngel;
    public GameObject menuPausa;

    public Collider orejaIzq;
    public Collider orejaDer;

    private CharacterController characterController;
    private Animator animatorController;
   
    public int daño = 30;

    public Slider vidaMaxima;
    
    public PlayerInput Cinnamon;

    public ContadorRollitos contador;

    public Estrella estrella;

    public Menu menupausa;

    Collider colliderCinnamon;

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
        //icono interfaz
        iconoCabeza.SetActive(true);
        //Movimiento Input
        movInput();
        //Rotacion
        Vector2 giro = Cinnamon.actions["GIRAR"].ReadValue<Vector2>();
        if (Derrota == false && menupausa.juegoPausado == false)
        {
            transform.Rotate(new Vector3(0, giro.x, 0));
            
        }
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

        //salto solo cuando esta en el suelo
        if (saltar && sobreSuelo)
        {
            rb.AddForce(Vector3.up * fuerzadeSalto, ForceMode.Impulse);
            saltar = false;
            sobreSuelo = false;
            
        }
        //animacion mov
        animatorController.SetFloat("Velocidad X", movX);
        animatorController.SetFloat("Velocidad Z", movZ);

        //Vida con slider

        // vidaMaxima.GetComponent<Slider>().value = daño;
        // if(vidaMaxima.GetComponent<Slider>().value == 0)
        {
         //   Derrota = true;
          //  Time.timeScale = 0;
        }

        //vidas con corazones
        if( daño == 30)
        {
            fullVida = true;
        }

        if(fullVida == true)
        {
          tresCorazones.SetActive(true);
          dosCorazones.SetActive(true);
          unCorazon.SetActive(true);
            
        }
        if( daño == 20)
        {
            mediaVida = true;
        }
        if(mediaVida == true)
        {
            tresCorazones.SetActive(false);
            dosCorazones.SetActive(true);
            unCorazon.SetActive(true);
           
        }
        if (daño == 10)
        {
            unaVida = true;
        }
        if(unaVida == true) 
        {
            tresCorazones.SetActive(false);
            dosCorazones.SetActive(false);
            unCorazon.SetActive(true);
        }
        if(daño == 0)
        {
            sinVida = true;
        }
        if (sinVida == true)
        {
            unCorazon.SetActive(false);
            Derrota = true;


        }
        //si te mueres
        if(Derrota == true)
        {
            Time.timeScale = 0;
        }
        //transformacion angel
        if(angelActivado == true)
        {
            Transformacion.gameObject.SetActive(true);
            CinnamonBase.gameObject.SetActive(false);
            iconoCabeza.SetActive(false);
            iconoCabezaAngel.SetActive(true);
            fullVida = true;
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
            orejaIzq.enabled = true;
            orejaDer.enabled = true;
        } 
        else
        {
            estaPegando = false;
            orejaIzq.enabled = false;
            orejaDer.enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //choque suelo
        if (collision.gameObject.tag == "Suelo")
        {
            sobreSuelo = true;
        }
         //Daño enemigos
        if(collision.gameObject.tag == "Enemigo" && estaPegando == false)
        {
            daño = daño - 10;
            Debug.Log("Te han hecho daño");
        }
        //Plataforma de pinchos
        if(collision.gameObject.tag == "Pinchos")
        {
            Derrota = true;
        }
        //Daño agua
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //coger estrella
        if (other.gameObject.tag == "Estrella")
        {
            angelActivado = true;
            Destroy(other.gameObject);
        }
        //Celda
        if(other.gameObject.tag == "Llave")
        {
            tieneLlave = true;
            celda.GetComponent<Celda>().Abrirse();
            Destroy(other.gameObject);
        }
        // ROLLITO :3
        if( other.gameObject.tag == "Rollito")
        {
            Destroy(other.gameObject);
            // -> "hey contador he cogio un rollito"
            contador.CuentaUnRollito();
        }
        if(other.gameObject.tag == "ZonaCofre")
        {
            zonaEstrella = true;
        }
        if (other.gameObject.tag == "Mar")
        {
            Derrota = true;

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
       
       
        //activar orejas
        
    }

}
