using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject UIManager;
    public int Score;
    public List<string> Ranks;

    public void DetermineRank()
    {
        if (Score < 6)
        {
            UIManager.GetComponent<UIManager>().UpdateScore(Score, Ranks[0]);
        }
        if (Score >= 6 && Score < 9)
        {
            UIManager.GetComponent<UIManager>().UpdateScore(Score, Ranks[1]);
        }
        if (Score >= 9 && Score < 12)
        {
            UIManager.GetComponent<UIManager>().UpdateScore(Score, Ranks[2]);
        }
        if (Score >= 12)
        {
            UIManager.GetComponent<UIManager>().UpdateScore(Score, Ranks[3]);
        }
    }
}
