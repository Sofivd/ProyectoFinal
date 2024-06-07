using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SlimesMov : MonoBehaviour
{
    public float speed = 8f;

    public Transform target;

    Collider colliderSlime;

    public CinnamonMov cinna;

    public GameObject Cinnamon;

    int dañoSlime = 20;

    Rigidbody rbSlime;

    public bool VisionSlimes;

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
            Destroy(gameObject);
        }
        if (VisionSlimes == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.LookAt(target);
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
            dañoSlime = dañoSlime - 5;
            rbSlime.AddForce(Vector3.back * 10, ForceMode.Impulse);

            Debug.Log("Slime ha perdido vida");
        }
    }
    public void Daño()
    {
        colliderSlime.enabled = true;
    }

}
