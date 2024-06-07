using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vuelo : MonoBehaviour
{  
    Rigidbody rb;

    public float movX, movZ;
    public float speed = 8f;
    public float impulso = 10f;

    public PlayerInput Cinnamon;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cinnamon = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        

        Ascender();
        Descender();
        Rotar();


        Vector3 nuevaVelocidad = new Vector3(movX * speed,0, movZ * speed);
        rb.velocity = nuevaVelocidad;

        //Movimiendo arriba y abajo
        
    }
    public void movInput()
    {
        Vector2 mov = Cinnamon.actions["MovimientoAngel"].ReadValue<Vector2>();
        // mov = (1,0);
        movX = mov.x;
        movZ = mov.y;
        Vector3 haciaAdelante = mov.y * speed * transform.forward;
        Vector3 deLado = mov.x * speed * transform.right;
        Vector3 movimiento = haciaAdelante + deLado;
        movimiento.y = rb.velocity.y;
        rb.velocity = movimiento;
    }
    public void Ascender()
    {
        if (Cinnamon.actions["ASCENDER"].IsPressed())
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
    public void Descender()
    {
        if (Cinnamon.actions["DESCENDER"].IsPressed())
        {
            rb.AddForce(-Vector3.up * 10, ForceMode.Impulse);  
        }
    }
    public void Rotar()
    {
        if (Cinnamon.actions["GIRAR2"].IsPressed())
        {
            Vector2 giro = Cinnamon.actions["GIRAR2"].ReadValue<Vector2>();
            transform.Rotate(new Vector3(0, giro.x, 0));
        }
        
    }

}
