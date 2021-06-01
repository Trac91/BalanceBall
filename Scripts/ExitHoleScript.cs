using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHoleScript : MonoBehaviour
{
    private Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallControlScript.setWinToTrue();
        

        if (collision.transform.name == "Ball")
        {
             Score.score += 100;
          // Score.IncrementScore();
        }
    }
}
