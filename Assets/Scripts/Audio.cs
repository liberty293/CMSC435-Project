using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    //Bpm of our song Happy Trancun is 123 bpm
    public Music song;
    private float secPerBeat;
    float positionInSeconds;
    public float timeStarted;
    public AudioSource music;
    // Start is called before the first frame update
    private void Awake()
    {
        music = GetComponent<AudioSource>();
        music.clip = song.song;
    }
    void Start()
    {
        secPerBeat = 60f / song.bpm;
        timeStarted = (float)AudioSettings.dspTime;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        positionInSeconds = (float)(AudioSettings.dspTime - timeStarted);
        song.posInBeats = positionInSeconds / secPerBeat;
     }

}
