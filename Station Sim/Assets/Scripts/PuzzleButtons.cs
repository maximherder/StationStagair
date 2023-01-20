using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtons : MonoBehaviour
{
    public GameObject PuzzlePiece;

    //Ik zou lege functies gewoon weghalen.

    /*
     * Deze manier van werken is prima wanneer er nog niet al te veel puzzelstukjes zijn en zolang je in je eentje werkt. 
     * Ik zou later aanraden dit op een flexibelere manier te doen.
     */
    public void TogglePiece()
    {
        if (PuzzlePiece.activeInHierarchy) //Hier zou ik de == true gewoon weglaten.
            PuzzlePiece.SetActive(false);
        else
            PuzzlePiece.SetActive(true);
    }
}
