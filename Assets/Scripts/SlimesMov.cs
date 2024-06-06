using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimesMov : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform target;
    Collider colliderSlime;
    public CinnamonMov cinna;
    public GameObject Cinnamon;
    int dañoSlime = 20;
    void Start()
    {
        colliderSlime = GetComponent<Collider>();
        //colliderSlime.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cinnamon")
        {
            //transform.position = new Vector3(-transform.position.x, 0, 0);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Orejas")
        {
            dañoSlime = dañoSlime - 10;
            Debug.Log("Slime ha perdido vida");
        }
    }

    public void Daño()
    {
        colliderSlime.enabled = true;
    }
}
