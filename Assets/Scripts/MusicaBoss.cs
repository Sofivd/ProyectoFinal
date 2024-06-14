using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaBoss : MonoBehaviour
{
    public AudioSource musicaBossFinal;
    public AudioSource bandaSonora;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cinnamon")
        {
            musicaBossFinal.Play();
            bandaSonora.Pause();
        }
    }
}
