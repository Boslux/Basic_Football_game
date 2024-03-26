using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreData", menuName = "Score System/Score Data")]
public class ScoreController : ScriptableObject
{
    public int scoreP1;
    public int scoreP2;
}
