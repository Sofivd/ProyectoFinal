using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public GameObject MenuPausa;

    public GameObject botonVolverJuego;

    public bool juegoPausado;

    public PlayerInput Cinnamon;

    public AudioSource bandaSonora;

    void Update()
    {
      
    }
    public void Pausar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            MenuPausa.SetActive(true);
            Time.timeScale = 0;
            juegoPausado = true;
            EventSystem.current.SetSelectedGameObject(botonVolverJuego);
            bandaSonora.Pause();
        }
        else
        {
            bandaSonora.Play();
        }
    }
}
