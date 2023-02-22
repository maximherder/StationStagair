using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystemScript : MonoBehaviour
{
    public int Points;
    public TextMeshProUGUI PointsText; 
    /* Je kunt dit prima in dit script doen, het heeft mijn voorkeur om een aparte UIManager te gebruiken om tekst etc. te updaten wanneer deze veranderd. 
     * Ik gok dat je vast wel eens van de SOLID principes gehoord hebt, dit past daar goed in.
     */


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
