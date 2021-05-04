using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fam : SyncAnimation
{
    bool metfam = false;
    protected override void Update()
    {
        if (!metfam)
        {
            var timing = (spawner.NumBeatsAdvance - (8 - song.posInBeats)) / spawner.NumBeatsAdvance;
            transform.position = Vector3.LerpUnclamped(initPosition, mainCharacter.position, timing);
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(BearTag) )
        {
            mainCharacter.GetComponentInChildren<Animator>().SetBool("done", true);
            mainCharacter.GetChild(0).localPosition = new Vector3(mainCharacter.localPosition.x, 0, mainCharacter.localPosition.z);
            metfam = true;
        }
    }

  
}
