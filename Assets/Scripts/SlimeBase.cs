using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAzul : MonoBehaviour
{
    public Material materialSlimeBase;
    public Material materialDaņo;
    public Material materialBase;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orejas")
        {
            materialSlimeBase.color = materialDaņo.color;
        }
        else
        {
            materialSlimeBase.color = materialBase.color;
        }
    }
}
