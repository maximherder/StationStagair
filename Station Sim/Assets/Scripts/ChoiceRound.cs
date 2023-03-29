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
    [TextArea(2, 10)]
    public string Hint;

    public GameObject Piece;
    public GameObject PreviewPiece;
    public GameObject ToDeconstruct;
    public bool Correct;

}

  