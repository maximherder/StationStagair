using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    //hier lijst van gewoon die class choicemanager, lijst heeft rondes (dus steeds 2 keuzes) dus die heeft dan parameters voor goed/fout, en gameobject en titel
    public List<ChoiceRound> Rounds;
    public GameObject UIManager;
    public GameObject PopupManager;
    public GameObject PieceConstructionManager;
    public GameObject Cam;
    public GameObject Train;
    public GameObject ScoreManager;
    public GameObject PreviewObject;
    public GameObject LogText;
    public GameObject Transition;

    [SerializeField]
    private GameObject Roads;
    private int _index = 0;
    private int _score;
    private int _timeCount;
    private bool _firstGuess = true;
    private bool _wrongWasSelected = false;

    /// <summary>
    /// Called by clicking on the "Build" button
    /// </summary>
    public void StartRound()
    {
        UIManager.GetComponent<UIManager>().UpdateChoicePanels(Rounds[_index].Choice1.ChoiceTitle, Rounds[_index].Choice2.ChoiceTitle);
        UIManager.GetComponent<UIManager>().ToggleChoicePanel();
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    /// <summary>
    /// Called by clicking on the Choice Panels
    /// </summary>
    /// <param name="choice">This value keeps track of which Choice Panel was selected</param>
    public void CheckAnswer(int choice)
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        if (choice == 0)
        {
            if (Rounds[_index].Choice1.Correct) //Right Choice
            {
                FindObjectOfType<AudioManager>().Play("CorrectFX");
                PieceConstructionManager.GetComponent<PieceConstructionManager>().PuzzlePiece = Rounds[_index].Choice1.Piece;
                PieceConstructionManager.GetComponent<PieceConstructionManager>().TogglePiece();
                if (!_wrongWasSelected)
                {
                    LogText.GetComponent<LogText>().AddChoiceToFile(_index, Rounds[_index].Choice1.ChoiceTitle, "-");
                }
                EndRound();
                CheckStage();
            }
            else //Wrong Choice
            {
                FindObjectOfType<AudioManager>().Play("WrongFX");
                UIManager.GetComponent<UIManager>().ToggleChoicePanel();
                PopupManager.GetComponent<PopupScript>().DisplayNewText(Rounds[_index].Choice1.Hint);
                if (_firstGuess)
                {
                    LogText.GetComponent<LogText>().AddChoiceToFile(_index, Rounds[_index].Choice1.ChoiceTitle, Rounds[_index].Choice1.Hint);
                }
                _wrongWasSelected = true;
                _firstGuess = false;

            }
        }
        else if (choice == 1)
        {
            if (Rounds[_index].Choice2.Correct)
            {
                FindObjectOfType<AudioManager>().Play("CorrectFX");
                PieceConstructionManager.GetComponent<PieceConstructionManager>().PuzzlePiece = Rounds[_index].Choice2.Piece;
                PieceConstructionManager.GetComponent<PieceConstructionManager>().TogglePiece();
                if (!_wrongWasSelected)
                {
                    LogText.GetComponent<LogText>().AddChoiceToFile(_index, Rounds[_index].Choice2.ChoiceTitle, "-");
                }
                EndRound();
                CheckStage();
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("WrongFX");
                UIManager.GetComponent<UIManager>().ToggleChoicePanel();
                PopupManager.GetComponent<PopupScript>().DisplayNewText(Rounds[_index].Choice2.Hint);
                if (_firstGuess)
                {
                    LogText.GetComponent<LogText>().AddChoiceToFile(_index, Rounds[_index].Choice2.ChoiceTitle, Rounds[_index].Choice2.Hint);
                }
                _wrongWasSelected = true;
                _firstGuess = false;
            }
        }
    }

    private void EndRound()
    {
        if (_firstGuess)
        {
            ScoreManager.GetComponent<ScoreManager>().Score++;
        }
        _firstGuess = true;
        _wrongWasSelected = false;

        if (PreviewObject != null)
            PreviewObject.SetActive(false);

        UIManager.GetComponent<UIManager>().ToggleChoicePanel();
        FindObjectOfType<TotalProgressBar>().UpdateProgress();

        if (_index + 1 != Rounds.Count)
            _index++;
        else
        {
            Roads.SetActive(true);
            PopupManager.GetComponent<PopupScript>().BuildButton.SetActive(false);
            FindObjectOfType<AudioManager>().Play("GameComplete");
            ScoreManager.GetComponent<ScoreManager>().DetermineRank();
            StartCoroutine(Ending());
        }
    }

    private void CheckStage()
    {
        if (_index == 5)
        {
            UIManager.GetComponent<UIManager>().ToggleDecommissionBorder();
            PopupManager.GetComponent<PopupScript>().DecommissionDialogue();
            Train.GetComponent<TrainScript>().Decommissioned = true;
        }

        if (_index == 9)
        {
            UIManager.GetComponent<UIManager>().ToggleDecommissionBorder();
            PopupManager.GetComponent<PopupScript>().DisplayNewText("Good job! The station is now functional again, carry on with the rest of the construction!");
            PieceConstructionManager.GetComponent<PieceConstructionManager>().MoveTunnel();
            Train.GetComponent<TrainScript>().Decommissioned = false;
        }
    }

    /// <summary>
    /// Called by Hover Enter event on the Choice Buttons
    /// </summary>
    /// <param name="choice">This value keeps track of which Choice Panel was selected</param>
    public void ShowPreview(int choice)
    {
        if (choice == 0)
        {
            PreviewObject = Rounds[_index].Choice1.PreviewPiece;
        }
        if (choice == 1)
        {
            PreviewObject = Rounds[_index].Choice2.PreviewPiece;
        }
        if (PreviewObject != null)
            PreviewObject.SetActive(true);
    }

    /// <summary>
    /// Called by the Hover Exit event on the Choice Buttons
    /// </summary>
    /// <param name="choice">This value keeps track of which Choice Panel was selected</param>
    public void HidePreview(int choice)
    {
        if (choice == 0)
        {
            PreviewObject = Rounds[_index].Choice1.PreviewPiece;
        }
        if (choice == 1)
        {
            PreviewObject = Rounds[_index].Choice2.PreviewPiece;
        }
        if (PreviewObject != null)
            PreviewObject.SetActive(false);
    }

    private IEnumerator Ending()
    {
        yield return new WaitForSeconds(4);
        StartCoroutine(Transition.GetComponent<StartScript>().EndGame());
        yield return new WaitForSeconds(1);
        Cam.GetComponent<IsometricCam>().ZoomToRaalte();
        UIManager.GetComponent<UIManager>().DisplayEndResults();
    }

}
