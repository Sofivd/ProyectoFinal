using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonSaltar : MonoBehaviour
{
    
    void Start()
    {
        
    }
    public void Skip()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
