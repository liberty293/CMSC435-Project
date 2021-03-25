using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Animations;
using UnityEngine;

public class SyncAnimation : MonoBehaviour
{

    float timing; // to be replaced with position in beat from JoelScript
    Transform hitPosition;


    // Update is called once per frame
    void Awake() 
    {
        hitPosition = GameObject.FindGameObjectWithTag("Finish").transform;
        StartCoroutine(playAnim());
    }

    IEnumerator playAnim() //posToBeat is a float 0-1 that says where in song is close to beat
    {

        while (timing<1)
        {
            timing += .001f;
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, hitPosition.position.z, timing));
            yield return null;
        }
        if (timing >= 1) timing = 0;
        transform.position = new Vector3(transform.position.x, transform.position.y, hitPosition.position.z);
        Destroy(gameObject);
    }
}
