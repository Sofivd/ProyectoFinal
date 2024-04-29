using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celda : MonoBehaviour
{
    public CinnamonMov Cinna;
    private CharacterController characterController;
    private Animator animatorController;
    void Start()
    {

    }


    void Update()
    {

        Cinna.Rescate();
           // {
         //   animatorController.SetBool("TieneLaLlave", true);
          //  }
        
            
       
    }
  
}
