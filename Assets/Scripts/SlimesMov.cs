using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimesMov : MonoBehaviour
{
    public float speed = 1.0f;
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
