using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetSlimes : MonoBehaviour
{
    public GameObject Cinnamon;

    public SlimesMov slimes;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cinnamon")
        {
            slimes.VisionSlimes = true;
        }
    }
}


