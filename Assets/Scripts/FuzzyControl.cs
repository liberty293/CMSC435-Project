using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyControl : MonoBehaviour
{
    [SerializeField]
    private Controls controls;
    public Animator AnimControl;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("calibration"))
        {
            var parent = transform.parent;
            parent.DetachChildren();
            parent.position = new Vector3(parent.position.x, parent.position.y, PlayerPrefs.GetFloat("calibration"));
            transform.parent = parent;
            Debug.Log("I collaborated");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(controls.Jump))
        {
            AnimControl.Play("Jump");
        }
        
        if (Input.GetKeyDown(controls.Roll)) AnimControl.Play("Roll");
        if (Input.GetKeyDown(controls.Shoot)) AnimControl.Play("Bird",1);
    }
}
