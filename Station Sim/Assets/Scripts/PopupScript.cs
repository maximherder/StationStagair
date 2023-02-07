using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupScript : MonoBehaviour
{
    public TextMeshProUGUI PopupText;
    public GameObject Panel;
    public TextScript textScript;
    public GameObject StartButton;

    private string _text;
    private Queue<string> _textQueue;

    private void Start()
    {
        _textQueue = new Queue<string>();
        StartDialogue();
        NextText();
    }

    public void StartDialogue()
    {
        _textQueue.Clear();

        foreach(string sentence in textScript.Sentences)
        {
            _textQueue.Enqueue(sentence);
        }
    }

    public void NextText()
    {
        Debug.Log("MEE");
        if (_textQueue.Count == 0)
        {
            Panel.SetActive(false);
            StartButton.SetActive(true);
            return;
        }

        string sentence = _textQueue.Dequeue();
        PopupText.text = sentence;
    }

}
