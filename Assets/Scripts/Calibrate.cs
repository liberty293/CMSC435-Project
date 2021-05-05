using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Calibrate : MonoBehaviour
{
    float[] hits = new float[6] ;
    public TextMeshProUGUI calibInfo;
    public SendBeats beatSender;
    public Button Mainmenu;
    int index = 0;
    float average;
    public int consistancy = 5; // how many times needed within variance
    int consistant = 0; //how many times you hit within variance
    public float variance = 1.5f;
    bool done;

    private void Awake()
    {
 //       PlayerPrefs.DeleteKey("calibration");
        done = false;
    }
    public void RecordPos(float pos)
    {
        if (index >= 6) index = 0;
        hits[index] = pos;
        index++;
    }

    public void FindAve(float newPos)
    {
//        Debug.Log(newPos);
        if (done) return;
        average = hits.Average();
        //Debug.Log(average);
        if(Math.Abs(average - newPos) > variance)
        {
            RecordPos(newPos);
 //           consistant = 0;
        }
        else
        {
            consistant++;
        }

        if(consistant == consistancy)
        {
            done = true;
            EndCalibration();
        }
        
    }

    private void EndCalibration()
    {
        calibInfo.text = "Calibration Complete";
        beatSender.enabled = false;
        Mainmenu.gameObject.SetActive(true);
        GetComponentInChildren<Animator>().SetBool("done", true);
        PlayerPrefs.SetFloat("calibration", average);
        Debug.Log(average);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
