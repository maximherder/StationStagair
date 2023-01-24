using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtons : MonoBehaviour
{
    public GameObject PuzzlePiece;

    public void TogglePiece()
    {
        if (PuzzlePiece.activeInHierarchy)
            PuzzlePiece.SetActive(false);
        else
            PuzzlePiece.SetActive(true);
    }
}
