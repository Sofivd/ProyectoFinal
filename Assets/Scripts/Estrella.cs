using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrella : MonoBehaviour
{
    public Transform target;

    public float speed = 1.0f;

    public CinnamonMov Cinnamon;

    public AudioSource sonidoEstrella;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void vieneLaEstrella()
    {
        if(Cinnamon.zonaEstrella == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            sonidoEstrella.Play();
        }
        

    }
}
