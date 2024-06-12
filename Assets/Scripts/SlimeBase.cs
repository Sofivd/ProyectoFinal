using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAzul : MonoBehaviour
{
    public Material materialSlimeBase;
    public Material materialDaño;
    public Material materialBase;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orejas")
        {
            materialSlimeBase.color = materialDaño.color;
        }
        else
        {
            materialSlimeBase.color = materialBase.color;
        }
    }
}
