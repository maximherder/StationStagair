using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupScript : MonoBehaviour
{
    public TextMeshProUGUI PopupText;
    public GameObject DialoguePanel;
    public GameObject BuildButton;
    public TextScript textScript;

    private string _text;
    private Queue<string> _textQueue;
    private CanvasGroup _canvasGroup;


    private void Start()
    {
        DialoguePanel.SetActive(true);
        _textQueue = new Queue<string>();
        IntroDialogue();
        NextText();
    }

    public void IntroDialogue()
    {
        _textQueue.Clear();

        foreach (string sentence in textScript.IntroSentences)
        {
            _textQueue.Enqueue(sentence);
        }
    }

    public void DecommissionDialogue()
    {
        DialoguePanel.SetActive(true);
        _textQueue.Clear();

        foreach (string sentence in textScript.DecommissionSentences)
        {
            _textQueue.Enqueue(sentence);
        }
        NextText();
    }

    public void NextText()
    {
        if (_textQueue.Count == 0)
        {
            DialoguePanel.SetActive(false);
            return;
        }
        string sentence = _textQueue.Dequeue();
        PopupText.text = sentence;
    }

    public void DisplayNewText(string text)
    {
        DialoguePanel.SetActive(true);
        PopupText.text = text;
    }

}
