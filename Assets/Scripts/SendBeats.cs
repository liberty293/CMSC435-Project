using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBeats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ListOfBeats beats;
    public GameObject obstacles;
    private float beatcount = 0; //to be replaced with actual beat count from joel script
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(beatcount >= beats.Beats[0])
        {
            Instantiate(obstacles);
            beats.Beats.RemoveAt(0);
        }
        Debug.Log(beatcount);
        beatcount += Time.deltaTime;
    }
}
