using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Personaje : MonoBehaviour
{
    private int velocidad = 6;
    private int salto=15;
    private Rigidbody2D rg;
    private bool toca_piso;
    private bool doble_salto;
    [SerializeField]
    private LayerMask capa_piso;
    [SerializeField]
    private float radio_validacion;
    [SerializeField]
    private Transform validacion_piso;
    private Animator anim;
    private bool vivo;
    private static Personaje instancia;

    public bool Vivo { get => vivo; set => vivo = value; }
    public static Personaje Instancia { get => instancia; set => instancia = value; }






    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Instancia = new Personaje();
        Instancia.Vivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Instancia.Vivo==true)
        {
            if (Input.touchCount > 0 && (toca_piso == true || doble_salto == false))
            {
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Began)
                {
                    rg.velocity = new Vector2(rg.velocity.y, salto);
                    doble_salto = true;
                }
            }
           
        }
        else 
        {
            velocidad = 0;
            salto = 0;
        }
        
    }
    private void FixedUpdate()
    {
        toca_piso = Physics2D.OverlapCircle(validacion_piso.position, radio_validacion, capa_piso);
        if (Instancia.Vivo==true)
        {
     
            rg.velocity = new Vector2(velocidad, rg.velocity.y);
            if (toca_piso == true)
            {
                doble_salto = false;
            }
        }
        else
        {
            velocidad = 0;
            salto = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Velocidad"))
        {
            velocidad += 2;
        }
        if(collision.gameObject.tag.Equals("Fuego"))
        {
          
            anim.SetBool("Muerte_Fuego", true);
            Esta_Muerto();
        }
        if (collision.gameObject.tag.Equals("Acido"))
        {
            
            anim.SetBool("Muerte_Acido", true);
            Esta_Muerto();


        }
        if(collision.gameObject.tag.Equals("Cambio_Camara"))
        {
            Camara.Instancia.Camara_y = true;
        }
        if (collision.gameObject.tag.Equals("Cambio_CamaraX"))
        {
            Camara.Instancia.Camara_y = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Pinchos"))
        {
           
            anim.SetBool("Muerte_Pinchos", true);
            Esta_Muerto();
            
        }
    }
    private void Esta_Muerto()
    {
        Instancia.Vivo = false;
        velocidad = 0;
        salto = 0;
        transform.localScale = new Vector3(2f, 2f, 2f);
       
    }

}
