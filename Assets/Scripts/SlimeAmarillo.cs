using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAmarillo : MonoBehaviour
{
    public Material materialSlime;
    public Material materialDaño;
    public Material materialBase;

    public GameObject dentro;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orejas")
        {
            Debug.Log("GOLPE OREJAS");
            dentro.GetComponent<Renderer>().material =  materialDaño;
            Invoke("ponerNormal", .5f);

        } 
    }
    void ponerNormal()
    {
             Debug.Log("SAKE OREJAS");
            dentro.GetComponent<Renderer>().material = materialBase;
    }
}
