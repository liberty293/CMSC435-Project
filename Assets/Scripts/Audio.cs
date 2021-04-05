﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public Scroller beat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.GetKeyDown("space"))
            {
                startPlaying = true;
                music.Play();
            }
        }
    }
}
