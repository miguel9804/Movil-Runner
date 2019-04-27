using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reinicio : MonoBehaviour
{
    [SerializeField]
    private GameObject reinicio;
    // Start is called before the first frame update
    void Start()
    {
        reinicio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Personaje.Instancia.Vivo == false)
        {
            reinicio.SetActive(true);
            if(Input.touchCount>0)
            {
                SceneManager.LoadScene("Runner");
            }
        }
    }
}
