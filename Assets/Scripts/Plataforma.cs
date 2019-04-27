using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField]
    private GameObject plataformas;
    [SerializeField]
    private Transform plataforma;
    private bool crear;
   

    

    // Start is called before the first frame update
    void Start()
    {
        
        crear = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if(crear == true)
        {
            CrearPlataformas();
            crear = false;
        }
    }
    void CrearPlataformas()
    {
      
       Instantiate(plataformas, plataforma.transform.position, Quaternion.identity);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            crear = true;
        }
    }
    
   
}
