using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextScript
{
    [TextArea(3, 10)]
    public string[] IntroSentences;
    [TextArea(3, 10)]
    public string[] DecommissionSentences;

}
