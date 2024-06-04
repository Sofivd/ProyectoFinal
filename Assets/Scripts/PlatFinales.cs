using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFinales : MonoBehaviour
{
    public bool elevarse = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(elevarse == true)
        {
            transform.Translate(12 * Vector3.up * Time.deltaTime);
        }
    }
}
