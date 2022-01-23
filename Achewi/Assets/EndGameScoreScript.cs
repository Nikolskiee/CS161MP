using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScoreScript : MonoBehaviour
{
    Text yourScore;
    // Start is called before the first frame update
    void Start()
    {
        yourScore = GetComponent<Text>();
        yourScore.text = "Your Score: " + ScoreScript.scoreValue; 
    }
}
