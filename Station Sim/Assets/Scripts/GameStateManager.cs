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
    public GameObject LogText;
    public GameObject Transition;

    [SerializeField]
    private readonly GameObject Roads;
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
        GetChoiceVectorAverage();

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

        HidePreview(0);
        HidePreview(1);

        UIManager.GetComponent<UIManager>().ToggleChoicePanel();
        FindObjectOfType<TotalProgressBar>().UpdateProgress();

        if (_index + 1 != Rounds.Count)
            _index++;
        else
        {
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
            if (Rounds[_index].Choice1.PreviewPiece != null)
                Rounds[_index].Choice1.PreviewPiece.SetActive(true);
            else
            {
                if (Rounds[_index].Choice1.ToDeconstruct.GetComponent<Outline>() == null)
                {
                    var outline = Rounds[_index].Choice1.ToDeconstruct.AddComponent<Outline>();
                    outline.OutlineMode = Outline.Mode.OutlineAll;
                }
                Rounds[_index].Choice1.ToDeconstruct.GetComponent<Outline>().enabled = true;
            }
        }
        if (choice == 1)
        {
            if (Rounds[_index].Choice2.PreviewPiece != null)
                Rounds[_index].Choice2.PreviewPiece.SetActive(true);
            else
            {
                if (Rounds[_index].Choice2.ToDeconstruct.GetComponent<Outline>() == null)
                {
                    var outline = Rounds[_index].Choice2.ToDeconstruct.AddComponent<Outline>();
                    outline.OutlineMode = Outline.Mode.OutlineAll;
                }
                Rounds[_index].Choice2.ToDeconstruct.GetComponent<Outline>().enabled = true;
            }
        }
    }

    /// <summary>
    /// Called by the Hover Exit event on the Choice Buttons
    /// </summary>
    /// <param name="choice">This value keeps track of which Choice Panel was selected</param>
    public void HidePreview(int choice)
    {
        if (choice == 0)
        {
            if (Rounds[_index].Choice1.PreviewPiece != null)
                Rounds[_index].Choice1.PreviewPiece.SetActive(false);
            else
            {
                if (Rounds[_index].Choice1.ToDeconstruct.GetComponent<Outline>() != null)
                    Rounds[_index].Choice1.ToDeconstruct.GetComponent<Outline>().enabled = false;
            }
        }
        if (choice == 1)
        {
            if (Rounds[_index].Choice2.PreviewPiece != null)
                Rounds[_index].Choice2.PreviewPiece.SetActive(false);
            else
            {
                if (Rounds[_index].Choice2.ToDeconstruct.GetComponent<Outline>() != null)
                    Rounds[_index].Choice2.ToDeconstruct.GetComponent<Outline>().enabled = false;
            }
        }
    }

    private void GetChoiceVectorAverage()
    {
        Vector3 Vector1 = new Vector3();
        Vector3 Vector2 = new Vector3();
        if (Rounds[_index].Choice1.PreviewPiece != null)
            Vector1 = Rounds[_index].Choice1.PreviewPiece.transform.position;
        else
            Vector1 = Rounds[_index].Choice1.ToDeconstruct.transform.position;

        if (Rounds[_index].Choice2.PreviewPiece != null)
            Vector2 = Rounds[_index].Choice2.PreviewPiece.transform.position;
        else
            Vector2 = Rounds[_index].Choice2.ToDeconstruct.transform.position;
        Cam.GetComponent<IsometricCam>().MoveToAverage(Vector1, Vector2);
    }

    private IEnumerator Ending()
    {
        Roads.SetActive(true);
        PopupManager.GetComponent<PopupScript>().BuildButton.SetActive(false);
        FindObjectOfType<AudioManager>().Play("GameComplete");
        ScoreManager.GetComponent<ScoreManager>().DetermineRank();

        yield return new WaitForSeconds(4);
        StartCoroutine(Transition.GetComponent<StartScript>().EndGame());

        yield return new WaitForSeconds(1);
        Cam.GetComponent<IsometricCam>().ZoomToRaalte();
        UIManager.GetComponent<UIManager>().DisplayEndResults();
    }

}
