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
    public GameObject lifebird;
    Music song;
    public List<float> beats = new List<float>();
    public bool endgame = false;

    void Awake()
    {
        //can change for beat level;
        song = FindObjectOfType<Audio>().song;
        song.Lvl1Beats(beats);
        

    }
    private void Start()
    {
        endgame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Object.FindObjectOfType<Audio>().music.isPlaying || endgame) return;
        if((beatIndex < beats.Count) && (beats[beatIndex] <= song.posInBeats + NumBeatsAdvance))
        {
            int index = Random.Range(0, obstacles.Length);
            int life = Random.Range(0, 100);
            if (life <= song.lifeDifficulty)
            {
                var prefab = Instantiate(lifebird, transform.position, Quaternion.identity);
                prefab.SendMessage("RecordBeat", beats[beatIndex]);
            }
            else if (obstacles[index] != null)
            {
               // Debug.Log("sendsomething");
                var prefab = Instantiate(obstacles[index], transform.position, Quaternion.identity);
                prefab.SendMessage("RecordBeat", beats[beatIndex]);
            }
            beatIndex++;
            
        }
        


    }
}
