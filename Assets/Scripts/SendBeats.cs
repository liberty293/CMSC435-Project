using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBeats : MonoBehaviour
{
    // Start is called before the first frame update
    public int beatIndex = 0;
    [SerializeField]
    public int NumBeatsAdvance = 3;
    public GameObject[] obstacles = new GameObject[3];
    Music song;
    public List<float> beats = new List<float>();
    void Awake()
    {
        //can change for beat level;
        song = FindObjectOfType<Audio>().song;
        song.Lvl1Beats(beats);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Object.FindObjectOfType<Audio>().music.isPlaying) return;
        if((beatIndex < beats.Count) && (beats[beatIndex] <= song.posInBeats + NumBeatsAdvance))
        {
            int index = Random.Range(0, obstacles.Length - 1);
            if (obstacles[index] != null)
            {
                var prefab = Instantiate(obstacles[index], transform.position, Quaternion.identity);
                prefab.SendMessage("RecordBeat", beats[beatIndex]);
            }
            beatIndex++;
           // Debug.Log(beatIndex);
        }

    }
}
