using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField]
    private Transform personaje;
    [SerializeField]
    private float separar;
    private bool camara_y;
    private static Camara instancia;
    

    public bool Camara_y { get => camara_y; set => camara_y = value; }
    public static Camara Instancia { get => instancia; set => instancia = value; }

    void Start()
    {
        Instancia = new Camara();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Instancia.Camara_y == false)
        {
            transform.position = new Vector3(personaje.position.x + separar, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(personaje.position.x + separar, personaje.position.y, transform.position.z);
            transform.localScale = new Vector3(2, 2, 2);
        }
       
        
    }
  
}
