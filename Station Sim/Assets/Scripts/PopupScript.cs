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
    public GameObject ChoicePanel;

    private bool _gameStarted;
    private string _text;
    private Queue<string> _textQueue;

    private void Start()
    {
        _textQueue = new Queue<string>();
        _gameStarted = false;
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

    public void StartDialogue() // Deze naam kan verwarrend zijn, ik ga ervan uit dat je hier het dialoog dat verschijnt als je op de start button klikt bedoeld.
                                // Ik zou deze naam gebruiken wanneer je daadwerkelijk dialoog wilt starten. Verder niets op aan te merken.
    {
        _textQueue.Clear();
        StartButton.SetActive(false);
        _gameStarted = true;

        foreach (string sentence in textScript.PlaySentences)
        {
            _textQueue.Enqueue(sentence);
        }
        Panel.SetActive(true);
    }

    public void NextText() // Dit ziet er heel netjes uit, wordt deze functie aangeroepen door op een button te klikken?
    {
        if (_textQueue.Count == 0)
        {
            Panel.SetActive(false);
            if (_gameStarted)
            {
                ChoicePanel.SetActive(true);
                return;
            }
            else
            {
                StartButton.SetActive(true);
                return;
            }
        }

        string sentence = _textQueue.Dequeue();
        PopupText.text = sentence;
    }

}
