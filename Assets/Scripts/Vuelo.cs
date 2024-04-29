using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vuelo : MonoBehaviour
{
    public float movX, movZ;
    Rigidbody rb;
    public float speed = 8f;
    public float impulso = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        

        Vector3 nuevaVelocidad = new Vector3(movX * speed,0, movZ * speed);
        rb.velocity = nuevaVelocidad;

        //Movimiendo arria y abajo
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 Palante = new Vector3(movX * speed, impulso , movZ * speed);
            rb.velocity = Palante;
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 Palante = new Vector3(movX * speed, -impulso, movZ * speed);
            rb.velocity = Palante;
        }
        //Rotacion
        if (transform.rotation.eulerAngles.y < 90 || transform.rotation.eulerAngles.y > -90)
        {
            transform.Rotate(new Vector3(0, movX * 45, 0) * Time.deltaTime);
        }
    }
}
