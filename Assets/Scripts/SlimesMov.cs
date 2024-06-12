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
    public GameObject ParticulasMuerte;

    int daņoSlime = 20;

    Rigidbody rbSlime;

    public bool VisionSlimes;
    public bool cambiarColor;

    public Material materialSlime;
    public Material materialDaņo;
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
        if (daņoSlime == 0)
        {
            Destroy(gameObject);
            ParticulasMuerte.SetActive(true);
        }
        if (VisionSlimes == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.LookAt(target);
        }
        if(cambiarColor == true)
        {
            // materialSlime.color = materialDaņo.color;
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
            daņoSlime = daņoSlime - 5;
            ParticulasMuerte.SetActive(true);
            rbSlime.AddForce(-transform.forward * 10, ForceMode.Impulse);
            // cambiarColor = true;
           // materialSlime.color = materialDaņo.color;
            
            Debug.Log("Slime ha perdido vida");
        }
        else
        {
            // materialSlime.color = materialBase.color;
            ParticulasMuerte.SetActive(false);
        }
        if(other.gameObject.tag == "Mar")
        {
            Destroy(gameObject);
        }
    }
   
    public void Daņo()
    {
        colliderSlime.enabled = true;
    }

}
