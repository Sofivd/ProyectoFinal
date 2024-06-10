using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;

public class SlimesMov : MonoBehaviour
{
    public float speed = 8f;

    public Transform target;

    Collider colliderSlime;

    public CinnamonMov cinna;

    public GameObject Cinnamon;

    int da�oSlime = 20;

    Rigidbody rbSlime;

    public bool VisionSlimes;
    public bool cambiarColor;

    public Material materialSlime;
    public Material materialDa�o;
    public Material materialBase;
    void Start()
    {
        rbSlime = GetComponent<Rigidbody>();
        colliderSlime = GetComponent<Collider>();
        //colliderSlime.enabled = false;
        
    }
    void Update()
    {
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if (da�oSlime == 0)
        {
            Destroy(gameObject);
        }
        if (VisionSlimes == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.LookAt(target);
        }
        if(cambiarColor == true)
        {
            // materialSlime.color = materialDa�o.color;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cinnamon")
        {
            //transform.position = new Vector3(-transform.position.x, 0, 0);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.LookAt(target);
        }
        if (other.gameObject.tag == "Orejas")
        {
            da�oSlime = da�oSlime - 5;
            rbSlime.AddForce(-transform.forward * 10, ForceMode.Impulse);
            // cambiarColor = true;
            materialSlime.color = materialDa�o.color;
            Debug.Log("Slime ha perdido vida");
        }
        //else if ()
        {
            materialSlime.color = materialBase.color;
        }
    }
   /* public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Orejas")
        {

            materialDa�o.color = materialBase.color;

        }
    }
   */
    public void Da�o()
    {
        colliderSlime.enabled = true;
    }

}
