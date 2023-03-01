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
    public GameObject PopupPanel;
    public GameObject PieceConstructionManager;
    public int Index = 0;

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
        UIManager.GetComponent<UIManager>().UpdateChoicePanels(Rounds[Index].Choice1.ChoiceTitle, Rounds[Index].Choice2.ChoiceTitle);
        UIManager.GetComponent<UIManager>().ToggleChoicePanel();
    }

    /// <summary>
    /// Called by Choice Panels
    /// </summary>
    /// <param name="choice">This value keeps track of which Choice Panel was selected</param>
    public void CheckAnswer(int choice)
    {
        if (choice == 0)
        {
            if (Rounds[Index].Choice1.Correct) //Right Choice
            {
                //Score stuff
                PieceConstructionManager.GetComponent<PieceConstructionManager>().PuzzlePiece = Rounds[Index].Choice1.Piece;
                PieceConstructionManager.GetComponent<PieceConstructionManager>().TogglePiece();
                EndRound();
                CheckStage();
            }
            else //Wrong Choice
            {
                //Score stuff
                UIManager.GetComponent<UIManager>().ToggleChoicePanel();
                PopupPanel.GetComponent<PopupScript>().DisplayNewText(Rounds[Index].Choice1.Hint);
            }
        }
        else if (choice == 1)
        {
            if (Rounds[Index].Choice2.Correct)
            {
                PieceConstructionManager.GetComponent<PieceConstructionManager>().PuzzlePiece = Rounds[Index].Choice2.Piece;
                PieceConstructionManager.GetComponent<PieceConstructionManager>().TogglePiece();
                EndRound();
                CheckStage();
            }
            else
            {
                UIManager.GetComponent<UIManager>().ToggleChoicePanel();
                PopupPanel.GetComponent<PopupScript>().DisplayNewText(Rounds[Index].Choice2.Hint);
            }
        }        
    }

    private void EndRound()
    {
        UIManager.GetComponent<UIManager>().ToggleChoicePanel();
        if (Index + 1 != Rounds.Count)
            Index++;
        else
        {
            //play tree animation
            //build roads
            PopupPanel.GetComponent<PopupScript>().BuildButton.SetActive(false);
            UIManager.GetComponent<UIManager>().DisplayEndResults();
        }
    }

    private void CheckStage()
    {
        if (Index == 5)
        {
            UIManager.GetComponent<UIManager>().ToggleDecommissionBorder();
            PopupPanel.GetComponent<PopupScript>().DecommissionDialogue();

            //misschien een timer starten en als de volgende keuzes voor het station niet binnen die tijd gemaakt zijn, game over
            //als foute keuzes gemaakt worden, extra tijd van de timer aftrekken

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  om bij game over spel te herstarten ofzo
        }

        if (Index == 9)
        {
            UIManager.GetComponent<UIManager>().ToggleDecommissionBorder();
            PopupPanel.GetComponent<PopupScript>().DisplayNewText("Good job! The station is now functional again, carry on with the rest of the construction!");
            //automatisch het middenstuk van tunnel verschuiven naar goede plek

            PieceConstructionManager.GetComponent<PieceConstructionManager>().MoveTunnel();
        }
    }

    //coroutine voor buitendienststelling timer?
    private IEnumerator DecommissionTimer()
    {
        yield return null; 
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
