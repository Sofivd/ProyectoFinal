using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelDerrota : MonoBehaviour
{
    private void Start()
    {

    }
    public void VolverMenuPrincipal()
    {
        SceneManager.LoadScene("Juego");
    }
}
