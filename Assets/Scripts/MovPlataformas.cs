using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlataformas : MonoBehaviour
{
    bool MovDerecha = true;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.z > 35)
        {
            MovDerecha = true;
        }

        else if (transform.localPosition.z < 22)
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
        Debug.Log(MovDerecha + " " + transform.localPosition);
    }
        
    
}
