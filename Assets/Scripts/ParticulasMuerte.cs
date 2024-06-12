using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasMuerte : MonoBehaviour
{
    public float speed = 8f;

    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
