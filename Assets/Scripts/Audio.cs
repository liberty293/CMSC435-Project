using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    //Bpm of our song Happy Trancun is 123 bpm
    public float bpm = 123;
    public float secPerBeat;
    public float positionInSeconds;
    public float positionInBeats;
    public float timeStarted;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        secPerBeat = 60f / bpm;
        timeStarted = (float)AudioSettings.dspTime;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        positionInSeconds = (float)(AudioSettings.dspTime - timeStarted);
        positionInBeats = positionInSeconds / secPerBeat;
     }

}
