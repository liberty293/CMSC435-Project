using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Music")]
public class Music : ScriptableObject
{
    [SerializeField]
    private AudioClip easySong, medSong, hardSong;
//    [HideInInspector]
    public AudioClip song;
    [SerializeField]
    private int easybpm, medbpm, hardbpm;
    [SerializeField]
    private int easylife, medlife, hardlife;
 //   [HideInInspector]
    public int bpm;
    public int lifeDifficulty;
    public float posInBeats;
    public int beatsb4start = 4;
    [SerializeField]
    public string Hardness  { get; set; }
    void OnEnable()
    {
        Hardness = "easy";
    }
    public void SetDificulty(string difficulty)
    {
        
        switch (difficulty)
        {
            case "easy":
                bpm = easybpm;
                song = easySong;
                lifeDifficulty = easylife;
                break;
            case "medium":
                bpm = medbpm;
                song = medSong;
                lifeDifficulty = medlife;
                break;
            case "hard":
                bpm = hardbpm;
                song = hardSong;
                lifeDifficulty = hardlife;
                break;
            default:
                bpm = easybpm;
                song = easySong;
                lifeDifficulty = easylife;
                break;

        }

    }
    public virtual void Lvl1Beats(List<float> Beats)
    {
        for (int i=beatsb4start;i<=94; i++)
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
