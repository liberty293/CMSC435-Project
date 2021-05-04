using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrate_obstacle : SyncAnimation
{
    public Controls controls;
    bool hitable = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(BearTag) && !hitable)
        {
                hitable = true;
        }
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (hitable && Input.GetKeyDown(controls.Jump))
        {
            mainCharacter.gameObject.GetComponent<Calibrate>().FindAve(transform.position.z);
 //           Debug.Log(transform.position.z);
        }
    }
}
