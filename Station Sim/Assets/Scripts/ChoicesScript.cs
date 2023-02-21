using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoicesScript : MonoBehaviour
{
    //hier lijst van gewoon die class choicemanager, lijst heeft rondes (dus steeds 2 keuzes) dus die heeft dan parameters voor goed/fout, en gameobject en titel
    public List<ChoiceManager> Rounds;
    public TextMeshProUGUI Panel1;
    public TextMeshProUGUI Panel2;
    public GameObject UIManager;
    public GameObject PopupPanel;
    public GameObject PuzzleButtons;

    private int _index = 0;

    public void StartRound()
    {
        //build button op dezelfde hoogte als choices, allebei aan onderkant van het scherm anchoren, button grotere squire, met een bouwgerelateerde image er in
        Panel1.text = Rounds[_index].Choice1.ChoiceTitle;
        Panel2.text = Rounds[_index].Choice2.ChoiceTitle;
        UIManager.GetComponent<UIManager>().ToggleChoicePanel();


    }


    public void CheckAnswer(int choice)
    {
        if (choice == 0)
        {
            if (Rounds[_index].Choice1.Correct)
            {
                //goeie keuze logica uitvoeren (score stuff)
                PuzzleButtons.GetComponent<PuzzleButtons>().PuzzlePiece = Rounds[_index].Choice1.Piece;
                PuzzleButtons.GetComponent<PuzzleButtons>().TogglePiece();
                EndRound();
            }
            else
            {
                //foute keuze logica
                UIManager.GetComponent<UIManager>().ToggleChoicePanel();
                PopupPanel.GetComponent<PopupScript>().WrongChoice(Rounds[_index].Choice1.Hint);
                PopupPanel.SetActive(true);
            }
        }
        else if (choice == 1)
        {
            if (Rounds[_index].Choice2.Correct)
            {
                //goeie keuze logica uitvoeren (score stuff)
                PuzzleButtons.GetComponent<PuzzleButtons>().PuzzlePiece = Rounds[_index].Choice2.Piece;
                PuzzleButtons.GetComponent<PuzzleButtons>().TogglePiece();
                EndRound();

            }
            else
            {
                //foute keuze logica
                UIManager.GetComponent<UIManager>().ToggleChoicePanel();
                PopupPanel.GetComponent<PopupScript>().WrongChoice(Rounds[_index].Choice2.Hint);
                PopupPanel.SetActive(true);
            }
        }
        if (_index == Rounds.Count)
        {
            Debug.Log("GAME FINISHED");
            //game afronden (de nieuwe wegen bouwen, bomen springen omhoog, waterafvoer bij de noord transfer, end results scherm aan)
        }

        if (_index == 5)
        {
            Debug.Log("TRAINSTATION IS DECOMMISSIONED NOW, YOU HAVE 10 DAYS TO FINISH THE STATION");
            //hier de buitendienststelling popup
        }
    }

    public void EndRound()
    {
        UIManager.GetComponent<UIManager>().ToggleChoicePanel();
        _index++;
    }

}
