﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide ()
    {
        gameObject.SetActive(false);
    }

    public void Show ()
    {
        gameObject.SetActive(true);
    }
}
