using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    public ScoreController sc;
    void Update()
    {
        scoreText.text = "P1 " + sc.scoreP1 + "-" + sc.scoreP2 + " P2";
    }
}
