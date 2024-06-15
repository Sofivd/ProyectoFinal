using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFinales : MonoBehaviour
{
    public bool elevarse;
    public bool tienesRollitos = true;

    public GameObject camaraPlataformas;
    
    void Start()
    {
        
    }
    void Update()
    {
       if(tienesRollitos == true)
        {
            transform.Translate(12 * Vector3.up * Time.deltaTime); // me elevo
            Invoke("ActivarCam", 1f);
           
            if (transform.localPosition.y >= 51)
            {
                tienesRollitos = false;
            }
        }  
    }
    public void AscenderPlat()
    {
        tienesRollitos = true;
    }
    public void ActivarCam()
    {
        camaraPlataformas.SetActive(true);
        Invoke("DesactivarCam", 4f);
    }
    public void DesactivarCam()
    {
        camaraPlataformas.SetActive(false);
    }
}
