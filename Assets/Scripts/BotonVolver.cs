using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class BotonVolver : MonoBehaviour
{
    public GameObject menuPausa;
    public void Volver()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
    }
}
