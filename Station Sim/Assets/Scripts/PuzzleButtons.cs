using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtons : MonoBehaviour
{
    //public List<GameObject> PuzzlePieces;
    public GameObject PuzzlePiece;
    public GameObject RequiredPiece;

    public void TogglePiece()
    {
        if (RequiredPiece == null)
        {
            Construction();
        }
        else if (RequiredPiece.GetComponent<PieceValueScript>().IsComplete)
        {
            //building progress function here
            Construction();

        }
        else
        {
            Debug.Log("Missing Requirement!");
            //popup here
            //deduct points here
        }
    }

    public void Construction()
    {
        //hier zorgen dat die timer begint te lopen, en zodra die voorbij is (coroutine?) de waardes veranderen
        if (!PuzzlePiece.GetComponent<PieceValueScript>().IsComplete)
        {
            if (!PuzzlePiece.GetComponent<PieceValueScript>().IsInProgress)
            {
                PuzzlePiece.GetComponent<PieceValueScript>().IsInProgress = true;
                if (PuzzlePiece.activeInHierarchy)
                {
                    PuzzlePiece.SetActive(false);
                }
                else
                {
                    PuzzlePiece.SetActive(true);
                }
                PuzzlePiece.GetComponent<PieceValueScript>().IsComplete = true;
                PuzzlePiece.GetComponent<PieceValueScript>().IsInProgress = false;
            }
        }
    }
}
