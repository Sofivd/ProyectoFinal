using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinnamonMov : MonoBehaviour
{
    public float movX, movZ;
    Rigidbody rb;
    float speed = 8f;
    public bool sobreSuelo = false;
    public bool saltar = false;
    public float fuerzadeSalto = 10f;
    public GameObject Slime2;
    public GameObject Transformacion;
    public GameObject CinnamonBase;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Slime2.gameObject.SetActive(false);
        Transformacion.gameObject.SetActive(false);
        CinnamonBase.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        Vector3 nuevaVelocidad = new Vector3(movX * speed, rb.velocity.y, movZ * speed);
        rb.velocity = nuevaVelocidad;

        if (Input.GetButtonDown("Jump"))
        {
            saltar = true;

        }

        if (saltar && sobreSuelo)
        {
            rb.AddForce(Vector3.up * fuerzadeSalto, ForceMode.Impulse);
            saltar = false;
            sobreSuelo = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        sobreSuelo = true;


        if (collision.gameObject.tag == "Suelo")
        {
            sobreSuelo = true;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Estrella")
        {
            Slime2.gameObject.SetActive(true);
            Transformacion.gameObject.SetActive(true);
            CinnamonBase.gameObject.SetActive(false);
        }
    }
}
