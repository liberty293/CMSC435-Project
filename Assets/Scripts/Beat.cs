using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float beatTempo;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveToBeat()
    {
        transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
    }
}
