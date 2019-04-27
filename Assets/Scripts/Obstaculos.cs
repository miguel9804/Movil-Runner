using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{

    [SerializeField]
    private GameObject[] obstaculos;
    [SerializeField]
    private Transform crear_obstaculos;
    private bool crear;
    
    // Start is called before the first frame update
    void Start()
    {
        crear = true;
    }

    // Update is called once per frame
    void Update()
    {
        int random;
        random = Random.Range(1, 2);
        if (random == 1 && crear == true)
        {
            crear = false;
            CrearObstaculos();
        }
    }
    void CrearObstaculos()
    {
       
            Instantiate(obstaculos[Random.Range(0, obstaculos.Length)], crear_obstaculos.transform.position, Quaternion.identity);
        
    }
        
}
