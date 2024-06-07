using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuPausa;

    public bool juegoPausado;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            MenuPausa.SetActive(true);
            Time.timeScale = 0;
            juegoPausado = true;
        }
    }

    //public void SwitchCurrentActionMap()
    // { 
    // playerInput.SwitchCurrentActionMap("Menu")
    // }
    //public void Pausar()
   // {
      //  if (Cinnamon.actions["Pausa"].IsPressed())
     //   {
       //     MenuPausa.SetActive(true);
       //     Time.timeScale = 0;
        //    juegoPausado = true;
      //  }
  //  }
}
