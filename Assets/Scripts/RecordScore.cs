using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordScore : MonoBehaviour
{
    private int currentScore = 0;
    private int currentHiScore;
    public TextMeshProUGUI Score, HiScore;
    // Start is called before the first frame update
    void Start()
    {
       HiScore.enabled = false;
        Score.text = currentScore.ToString();
        currentHiScore = PlayerPrefs.HasKey("hiscore") ? DecodeScore(PlayerPrefs.GetInt("hiscore")) : 0;
    }

   public void AddScore(int num2add)
    {
        currentScore += num2add;
        Score.text = currentScore.ToString();
    }

    public void GetHighScore()
    {
        int newHiScore = currentHiScore < currentScore ? currentScore : currentHiScore;
        HiScore.text = "High Score " + newHiScore.ToString(); 
        PlayerPrefs.SetInt("hiscore", EncodeScore(newHiScore));
        HiScore.enabled = true;
    }

    int EncodeScore(int score)
    {
        int newScore;
        int seed = Random.Range(0, 10);
        //Debug.Log(seed);
        System.Random random = new System.Random(seed);
        int multiplier = random.Next(1000);
        //Debug.Log(multiplier);
        newScore = score * multiplier - random.Next(1000);
        string stringScore = newScore.ToString() + seed.ToString();
        Debug.Log(stringScore);
        return int.Parse(stringScore);
    }
    int DecodeScore(int score)
    {
        int newScore;
        string stringScore = score.ToString();
        int seed = int.Parse(stringScore[stringScore.Length - 1].ToString());
        Debug.Log(seed);
        System.Random random = new System.Random(seed);
        int multiplier = random.Next(1000);
        Debug.Log(multiplier);
        int subtractor = random.Next(1000);
        stringScore = stringScore.Substring(0, stringScore.Length - 1);
        newScore = (int.Parse(stringScore) + subtractor) / multiplier;
        return newScore;
    }

    public void ButtonEncode(int score)
    {
        HiScore.text = EncodeScore(score).ToString();
    }
    public void ButtonDecode(int score)
    {
        HiScore.text = DecodeScore(score).ToString();
    }
}
