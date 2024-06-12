using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diablo : MonoBehaviour
{
    public GameObject llave;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cinnamon")
        {
            Destroy(gameObject);
            llave.SetActive(true);
        }
    }
}
