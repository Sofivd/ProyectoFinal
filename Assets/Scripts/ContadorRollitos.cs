using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ContadorRollitos : MonoBehaviour
{
    public TextMeshProUGUI Contador;
    int rollitos = 0;
    public GameObject rollitosCanela;
    public GameObject cinnamon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Contador.text = "X " + rollitos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Rollito")
        {
            rollitos = rollitos + 1;
            Contador.text = rollitos.ToString();
            Destroy(other.gameObject);

        }
    }
}
