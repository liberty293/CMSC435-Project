﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dificulty : MonoBehaviour
{
    private int level = 1;
    private Audio songs;
    public GameObject endPrefab;
    [SerializeField]
    private Animator fuzzy;
    public TextMeshProUGUI LevelUI;
    public Music SetLevel;
    public GameObject[] levelObstacles;
    bool done = false;
    public RecordScore score;
    void Awake()
    {
        songs = GetComponent<Audio>();
    }
    private void Start()
    {
        StartCoroutine(updateLevel(level));
  //      Finished();
    }

    void Update()
    {
        if (!songs.GetComponent<AudioSource>().isPlaying)
        {
            level++;
            if (level <= 3)
            {
                StartCoroutine(updateLevel(level));
            }
            else if (!done)
            {

                Finished();
            }

        }
    }

    

    void Finished()
    {
        songs.enabled = false;
        GetComponent<SendBeats>().endgame = (done = true);
        songs.enabled = true;
        Instantiate(endPrefab, transform.position, Quaternion.identity);
        LevelUI.text = "You Win!";
        LevelUI.enabled = true;
        score.GetHighScore();
    }

    IEnumerator updateLevel(int level)
    {
        LevelUI.text = "Level: " + level.ToString();
        songs.enabled = false;
        GetComponent<SendBeats>().beatIndex = 0;
        GetComponent<SendBeats>().obstacles[level - 1] = levelObstacles[level - 1];
        songs.enabled = true;
        LevelUI.enabled = true;
        yield return new WaitForSeconds(2f);
        LevelUI.enabled = false;

    }
        
}
