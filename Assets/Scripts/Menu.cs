using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public GameObject MenuPausa;

    public bool juegoPausado;

    public PlayerInput Cinnamon;

    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Escape))
        { 
            MenuPausa.SetActive(true);
            Time.timeScale = 0;
            juegoPausado = true;
        }
       */
    }

    //public void SwitchCurrentActionMap()
    // { 
    // playerInput.SwitchCurrentActionMap("Menu")
    // }

    public void Pausar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            MenuPausa.SetActive(true);
            Time.timeScale = 0;
            juegoPausado = true;
        }
       
    }

}
