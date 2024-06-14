using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasMuerte : MonoBehaviour
{
    public float speed = 8f;

    public Transform target;

    public SlimesMov slime;

    public GameObject particulas;
    public GameObject bloqueoPuente;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // float step = speed * Time.deltaTime;
      //  transform.position = Vector3.MoveTowards(transform.position, target.position, step);
      transform.position = target.position;
        if(slime.dañoSlime == 0)
        {
            particulas.SetActive(true);
            bloqueoPuente.SetActive(false);
        }
    }
}
