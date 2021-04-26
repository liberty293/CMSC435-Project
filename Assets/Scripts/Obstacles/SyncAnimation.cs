using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Animations;
using UnityEngine;

public class SyncAnimation : MonoBehaviour
{
    int beatsAdvance;
    float beatNumber;
    public string BearTag = "Finish";
    float timing; // to be replaced with position in beat from JoelScript
    protected Transform mainCharacter;
    Vector3 initPosition;
    Music song;
    SendBeats spawner;

    // Update is called once per frame
    void OnEnable() 
    {
        song = Object.FindObjectOfType<Audio>().song;
        spawner = FindObjectOfType<SendBeats>();
        beatsAdvance = spawner.NumBeatsAdvance;
        mainCharacter = GameObject.FindGameObjectWithTag(BearTag).transform;
        initPosition = transform.position;
    }

    public void RecordBeat(float beat)
    {
        beatNumber = beat;
    }

    private void FixedUpdate()
    {
        var timing = (spawner.NumBeatsAdvance - (beatNumber - song.posInBeats))/ spawner.NumBeatsAdvance;
          transform.position = Vector3.LerpUnclamped(initPosition, mainCharacter.position, timing);
        if (timing >= 2) Destroy(gameObject);
 //       Debug.Log(gameObject.name + " : " +  "; " + spawner.NumBeatsAdvance + "; " + song.posInBeats + ";" + timing);
    }


}
