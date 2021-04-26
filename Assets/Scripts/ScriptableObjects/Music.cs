using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Music")]
public class Music : ScriptableObject
{
    public AudioClip song;
    public int bpm;
    public float posInBeats;
    public int beatsb4start = 4;

    public void Lvl1Beats(List<float> Beats)
    {
        for (int i=beatsb4start;i<94 + beatsb4start; i++)
        {
            Beats.Add(i);
            if (i < 32)
            {
                Beats[i-beatsb4start]=i;
                continue;
            }
            if((i < 63) && (i % 4 ==1)){
                Beats[i- beatsb4start] = (float)i-.5f;
                continue;
            }
            else if (i < 63)
            {
                Beats[i - beatsb4start] = i;
                continue;
            }
            Beats[i- beatsb4start] = i;


        }
    }
}
