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

    public AudioSource SonidoMuerte;

    int dañoSlime = 20;

    Rigidbody rbSlime;

    public bool VisionSlimes;
    public bool cambiarColor;

   
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
        if (dañoSlime == 0)
        { 
            ParticulasMuerte.SetActive(true);
            
            SonidoMuerte.Play();
            this.gameObject.SetActive(false);
            
           
        }
        if (VisionSlimes == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.LookAt(target);
        }
    }

    void Muerte()
    {
        Destroy(gameObject);
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
            dañoSlime = dañoSlime - 5;
            ParticulasMuerte.SetActive(true);
            rbSlime.AddForce(-transform.forward * 10, ForceMode.Impulse);
            Debug.Log("Slime ha perdido vida");
        }
        else
        {
            ParticulasMuerte.SetActive(false);
        }
        if(other.gameObject.tag == "Mar")
        {
            Destroy(gameObject);
        }
    }
   
    public void Daño()
    {
        colliderSlime.enabled = true;
    }

}
