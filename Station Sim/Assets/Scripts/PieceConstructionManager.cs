using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceConstructionManager : MonoBehaviour
{
    public GameObject Cam;
    public GameObject PuzzlePiece;
    private GameObject _progressBar;
    private Vector3 _camOffset;
    private ObjectLerpScript _lerpScript;
    //public GameObject ScoreSystem;


    private void Start()
    {
        _camOffset = new Vector3(40, 0, 40);
        _progressBar = (GameObject)Resources.Load("CanvasTiny", typeof(GameObject));
    }


    public void TogglePiece()
    {
        PieceValueScript pieceValueScript = PuzzlePiece.GetComponent<PieceValueScript>();
        _lerpScript = PuzzlePiece.GetComponentInChildren<ObjectLerpScript>();

        if (PuzzlePiece.activeInHierarchy)
        {
            //animatie voor deconstrucion --> lerp omlaag
            PuzzlePiece.SetActive(false);
        }
        else
        {
            PuzzlePiece.SetActive(true);
            PlayConstructionAnimation(pieceValueScript);
        }
    }

    private void PlayConstructionAnimation(PieceValueScript pieceValueScript)
    {
        GameObject realProgressBar = Instantiate(_progressBar, (PuzzlePiece.transform.position + new Vector3(0, 10, 0)), Quaternion.identity);
        realProgressBar.GetComponentInChildren<ProgresBarScript>().BuildTime = pieceValueScript.BuildingTime;
        Cam.GetComponent<IsometricCam>().Trans = PuzzlePiece.transform.position + _camOffset;
        _lerpScript.SetDestination(pieceValueScript.BuildingTime);
    }

    private void PlayDestroyAnimation()
    {
        Cam.GetComponent<IsometricCam>().Trans = PuzzlePiece.transform.position + _camOffset;


    }

}
