using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celda : MonoBehaviour
{
    public CinnamonMov Cinna;
    private CharacterController characterController;
    private Animator animatorController;
    public GameObject Cinnamon;
    void Start()
    {
        animatorController = GetComponent<Animator>();
    }


    void Update()
    {

       // Cinna.Rescate();
           
       
    }

    // La celda activa la animacion de abrirse cuando Cinnamon tenga la llave
    public void Abrirse()
    {
        
        animatorController.SetBool("TieneLaLlave", true);
    }
 
  }

    
