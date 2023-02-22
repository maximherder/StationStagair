using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextScript //Netjes, ik vind het heel clean om dit als container te gebruiken. :D
{
    [TextArea(3, 10)]
    public string[] IntroSentences;

    [TextArea(3, 10)]
    public string[] PlaySentences;


}
