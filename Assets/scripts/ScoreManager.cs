using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    double score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void raiseScore(double points) {
        score += points;
        scoreText.text = score + "";
    }

    public double getTotalScore() {
        return score;
    }
}