using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddle : SyncAnimation
{
    public Controls controls;
    bool pointsAwarded = false;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(BearTag) && !pointsAwarded)
        {
            if (other.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Jump") && other.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime<.5)
            {
               // Debug.Log("Award Points");
                score.AddScore(points);
                pointsAwarded = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!pointsAwarded)
        {
            other.GetComponentInChildren<Player>().TakeDamage(1);
        }
    }
}
