﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void CargarNivel(string name)
    {
        if(Input.touchCount>0)
        {
            SceneManager.LoadScene(name);
        }
        
    }
    
}
