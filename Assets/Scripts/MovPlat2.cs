using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlat2 : MonoBehaviour
{
    bool MovDerecha = true;
    void Start()
    {
        
    }

    // Movimiento plataforma izquierda
    void Update()
    {
        if (transform.localPosition.z > -8)
        {
            MovDerecha = true;
        }

        else if (transform.localPosition.z < -20)
        {
            MovDerecha = false;
        }
        if (MovDerecha == true)
        {
            transform.Translate(12 * Vector3.back * Time.deltaTime);
        }
        else
        {
            transform.Translate(12 * Vector3.forward * Time.deltaTime);
        }
       // Debug.Log(MovDerecha + " " + transform.localPosition);
    }

}
