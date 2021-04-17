using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Animator AnimControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AnimControl.Play("Jump");
        }
        
        if (Input.GetKeyDown(KeyCode.W)) AnimControl.Play("Roll");
    }
}
