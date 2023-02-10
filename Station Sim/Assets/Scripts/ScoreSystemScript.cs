using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystemScript : MonoBehaviour
{
    public int Points;
    public TextMeshProUGUI PointsText;

    private void Start()
    {
        Points = 0;
        PointsText = FindObjectOfType<TextMeshProUGUI>();
    }


    public void UpdatePoints(int points)
    {
        Points += points;
        PointsText.text = Points.ToString();
    }
}
