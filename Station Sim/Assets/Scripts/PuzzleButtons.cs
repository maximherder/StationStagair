using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtons : MonoBehaviour
{
    public GameObject PuzzlePiece;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePiece()
    {
        if (PuzzlePiece.activeInHierarchy == true)
            PuzzlePiece.SetActive(false);
        else
            PuzzlePiece.SetActive(true);
    }
}
