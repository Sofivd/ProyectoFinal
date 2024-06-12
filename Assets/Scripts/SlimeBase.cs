using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAzul : MonoBehaviour
{
    public Material materialSlimeBase;
    public Material materialDa�o;
    public Material materialBase;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orejas")
        {
            materialSlimeBase.color = materialDa�o.color;
        }
        else
        {
            materialSlimeBase.color = materialBase.color;
        }
    }
}
