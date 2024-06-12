using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAmarillo : MonoBehaviour
{
    public Material materialSlime;
    public Material materialDa�o;
    public Material materialBase;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orejas")
        {
            materialSlime.color = materialDa�o.color;
        }
        else
        {
            materialSlime.color = materialBase.color;
        }
    }
}
