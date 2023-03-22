using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject UIManager;
    public int Score;
    public List<string> Ranks;
    public string Rank;
    public GameObject LogText;

    public void DetermineRank()
    {
        if (Score < 6)
        {
            Rank = Ranks[0];
        }
        if (Score >= 6 && Score < 9)
        {
            Rank = Ranks[1];
        }
        if (Score >= 9 && Score < 12)
        {
            Rank = Ranks[2];
        }
        if (Score >= 12)
        {
            Rank = Ranks[3];
        }

        UIManager.GetComponent<UIManager>().UpdateScore(Score, Rank);
        LogText.GetComponent<LogText>().AddScoreToFile(Score.ToString(), Rank);
    }
}
