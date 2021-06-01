using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public GameObject scoreTextgo;
    TextMeshPro scoreText;
    // public GameObject ScoreBoard;
    public string scoretxt;

    private void Start()
    {

        //  scoretxt = score.GetComponent<ScoreBoard>();
        scoreText = scoreTextgo.GetComponent<TextMeshPro>();

    }
    //   public void IncrementScore()
    //  {

    //scoreText = scoreTextgo.GetComponent<TextMeshPro>();
    //score++;
    //this.scoreText.text = score.ToString();


    public void IncrementScore()
    {
        PlayerPrefs.SetInt("ScoreToUpdate", PlayerPrefs.GetInt("ScoreToUpdate", 0) + 100);
        score += 100;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(50, 50, 50, 50), score.ToString());
    }

}