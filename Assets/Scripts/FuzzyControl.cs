using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyControl : MonoBehaviour
{
    [SerializeField]
    private Controls controls;
    public Animator AnimControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(controls.Jump))
        {
            AnimControl.Play("Jump");
        }
        
        if (Input.GetKeyDown(controls.Roll)) AnimControl.Play("Roll");
    }
}
