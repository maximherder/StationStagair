using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChoiceManager : MonoBehaviour
{
    //hier lijst van gewoon die class choicemanager, lijst heeft rondes (dus steeds 2 keuzes) dus die heeft dan parameters voor goed/fout, en gameobject en titel
    public List<ChoiceRound> Rounds;
    public GameObject UIManager;
    public GameObject PopupManager;
    public GameObject PieceConstructionManager;

    private int _index = 0;
    private bool _decommissioned = false;
    private int _score;
    private int _timeCount;

    private void Update()
    {
        if (_decommissioned)
        {
           // _timeCount
        }
    }

    /// <summary>
    /// Called by "BuildButton"
    /// </summary>
    public void StartRound()
    {
        UIManager.GetComponent<UIManager>().UpdateChoicePanels(Rounds[_index].Choice1.ChoiceTitle, Rounds[_index].Choice2.ChoiceTitle);
        UIManager.GetComponent<UIManager>().ToggleChoicePanel();
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    /// <summary>
    /// Called by Choice Panels
    /// </summary>
    /// <param name="choice">This value keeps track of which Choice Panel was selected</param>
    public void CheckAnswer(int choice)
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        if (choice == 0)
        {
            if (Rounds[_index].Choice1.Correct) //Right Choice
            {
                //Score stuff
                PieceConstructionManager.GetComponent<PieceConstructionManager>().PuzzlePiece = Rounds[_index].Choice1.Piece;
                PieceConstructionManager.GetComponent<PieceConstructionManager>().TogglePiece();
                EndRound();
                CheckStage();
            }
            else //Wrong Choice
            {
                //Score stuff
                UIManager.GetComponent<UIManager>().ToggleChoicePanel();
                PopupManager.GetComponent<PopupScript>().DisplayNewText(Rounds[_index].Choice1.Hint);
            }
        }
        else if (choice == 1)
        {
            if (Rounds[_index].Choice2.Correct)
            {
                PieceConstructionManager.GetComponent<PieceConstructionManager>().PuzzlePiece = Rounds[_index].Choice2.Piece;
                PieceConstructionManager.GetComponent<PieceConstructionManager>().TogglePiece();
                EndRound();
                CheckStage();
            }
            else
            {
                UIManager.GetComponent<UIManager>().ToggleChoicePanel();
                PopupManager.GetComponent<PopupScript>().DisplayNewText(Rounds[_index].Choice2.Hint);
            }
        }        
    }

    private void EndRound()
    {
        UIManager.GetComponent<UIManager>().ToggleChoicePanel();
        if (_index + 1 != Rounds.Count)
            _index++;
        else
        {
            //play tree animation
            //build roads
            PopupManager.GetComponent<PopupScript>().BuildButton.SetActive(false);
            UIManager.GetComponent<UIManager>().DisplayEndResults();
        }
    }

    private void CheckStage()
    {
        if (_index == 5)
        {
            UIManager.GetComponent<UIManager>().ToggleDecommissionBorder();
            PopupManager.GetComponent<PopupScript>().DecommissionDialogue();

            //misschien een timer starten en als de volgende keuzes voor het station niet binnen die tijd gemaakt zijn, game over
            //als foute keuzes gemaakt worden, extra tijd van de timer aftrekken

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  om bij game over spel te herstarten ofzo
        }

        if (_index == 9)
        {
            UIManager.GetComponent<UIManager>().ToggleDecommissionBorder();
            PopupManager.GetComponent<PopupScript>().DisplayNewText("Good job! The station is now functional again, carry on with the rest of the construction!");
            PieceConstructionManager.GetComponent<PieceConstructionManager>().MoveTunnel();
        }
    }

    //coroutine voor buitendienststelling timer?
    private IEnumerator DecommissionTimer()
    {
        yield return null; 
    }
}
