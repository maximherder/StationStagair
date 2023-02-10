using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupScript : MonoBehaviour
{
    public TextMeshProUGUI PopupText;
    public GameObject Panel;
    public TextScript textScript;
    public GameObject BuildButton;
    public GameObject ChoicePanel;
    public GameObject ButtonManager;

    private bool _gameStarted;
    private bool _introDone;
    private bool _choicePanelActive;
    private string _text;
    private Queue<string> _textQueue;
    private CanvasGroup _canvasGroup;


    private void Start()
    {
        Panel.SetActive(true);
        _textQueue = new Queue<string>();
        _gameStarted = false;
        _introDone = false;
        IntroDialogue();
        NextText();

        _canvasGroup = ChoicePanel.GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        _choicePanelActive = false;
    }

    public void IntroDialogue()
    {
        _textQueue.Clear();

        foreach (string sentence in textScript.IntroSentences)
        {
            _textQueue.Enqueue(sentence);
        }
    }

    public void StartDialogue()
    {
        _textQueue.Clear();
        _gameStarted = true;
        if (!_introDone)
        {
            foreach (string sentence in textScript.PlaySentences)
            {
                _textQueue.Enqueue(sentence);
            }
            _introDone = true;
            Panel.SetActive(true);
        }
    }

    public void NextText()
    {
        if (_textQueue.Count == 0)
        {
            Panel.SetActive(false);
            if (_gameStarted)
            {
                ToggleChoicePanel();
                //ChoicePanel.SetActive(true);
                return;
            }
            else
            {
                //ButtonManager.GetComponent<ButtonManager>().ToggleChoicePanel();
                //BuildButton.SetActive(true);
                return;
            }
        }

        string sentence = _textQueue.Dequeue();
        PopupText.text = sentence;
    }

    public void WrongChoice()
    {
        Panel.SetActive(true);
        PopupText.text = "no";
    }


    public void ToggleChoicePanel()
    {
        _choicePanelActive = !_choicePanelActive;

        if (_choicePanelActive)
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
            //_choicePanel.SetActive(true);
        }
        if (!_choicePanelActive)
        {
            Debug.Log("skeebly");
            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = false;
            //_choicePanel.SetActive(false);
        }
    }

}
