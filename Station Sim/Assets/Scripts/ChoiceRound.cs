using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChoiceRound
{
    public Choice Choice1;
    public Choice Choice2;
}

[System.Serializable]
public class Choice
{
    [TextArea(2, 10)]
    public string ChoiceTitle;
    public GameObject Piece;
    public GameObject PreviewPiece;
    [TextArea(2, 10)]
    public string Hint;
    public bool Correct;

}


//after every choice made, add a function in GameStateManager that sends the right values (choicetitle, Hint, correct) under the right circumstances
//then append to a text file that LogText makes  