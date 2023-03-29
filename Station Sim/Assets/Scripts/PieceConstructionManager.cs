using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceConstructionManager : MonoBehaviour
{
    public GameObject Cam;
    public GameObject PuzzlePiece;
    public GameObject Tunnel;
    public GameObject TransferConnection;
    public GameObject DustCloud;

    private GameObject _progressBar;
    private Vector3 _camOffset;
    private ObjectLerpScript _lerpScript;
    //public GameObject ScoreSystem;


    private void Start()
    {
        _camOffset = new Vector3(40, 0, -50);
        _progressBar = (GameObject)Resources.Load("CanvasTiny", typeof(GameObject));
    }


    public void TogglePiece()
    {
        PieceValueScript pieceValueScript = PuzzlePiece.GetComponent<PieceValueScript>();
        _lerpScript = PuzzlePiece.GetComponentInChildren<ObjectLerpScript>();

        if (PuzzlePiece.activeInHierarchy)
        {
            PlayDestroyAnimation();
            FindObjectOfType<AudioManager>().PlayDestruction();
        }
        else
        {
            PuzzlePiece.SetActive(true);
            PlayConstructionAnimation(pieceValueScript);
            FindObjectOfType<AudioManager>().PlayConstruction();
        }
    }

    private void PlayConstructionAnimation(PieceValueScript pieceValueScript)
    {
        GameObject realProgressBar = Instantiate(_progressBar, (PuzzlePiece.transform.position + new Vector3(0, 10, 0)), Quaternion.identity);
        realProgressBar.GetComponentInChildren<ProgresBarScript>().BuildTime = pieceValueScript.BuildingTime;
        Cam.GetComponent<IsometricCam>().Trans = PuzzlePiece.transform.position + _camOffset;
        _lerpScript.Move = true;
        _lerpScript.SetDestination(pieceValueScript.BuildingTime, true);
    }

    private void PlayDestroyAnimation()
    {
        _lerpScript.Move = true;
        Cam.GetComponent<IsometricCam>().Trans = PuzzlePiece.transform.position + _camOffset;
        GameObject dust = Instantiate(DustCloud, PuzzlePiece.transform.position + new Vector3(0, 0, -15), Quaternion.Euler(0, 0, -90));
        _lerpScript.SetDestination(3, false);

    }

    public void MoveTunnel()
    {
        Tunnel.GetComponent<Animator>().Play("Tunnel Move");
        TransferConnection.GetComponent<Animator>().Play("Transfer Move");
    }

}
