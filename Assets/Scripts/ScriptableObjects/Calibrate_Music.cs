using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Calibration")]
public class Calibrate_Music : Music
{
    // Start is called before the first frame update
    public override void Lvl1Beats(List<float> Beats)
    {
        for (int i = beatsb4start; i <= 94; i++)
        {
            Beats.Add(i);
            Beats[i - beatsb4start] = i;
        }
    }
}
