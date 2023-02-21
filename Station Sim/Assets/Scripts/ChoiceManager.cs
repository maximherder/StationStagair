using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChoiceManager
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
    [TextArea(2, 10)]
    public string Hint;
    public bool Correct;

}
