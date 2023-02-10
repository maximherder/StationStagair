using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtons : MonoBehaviour
{
    public GameObject PuzzlePiece;
    public GameObject RequiredPiece;
    public GameObject Cam;
    //public GameObject ScoreSystem;
    private GameObject _progressBar;
    private Vector3 _camOffset;
    private ObjectLerpScript _lerpScript;


    private void Start()
    {
        //ScoreSystem = GameObject.Find("txtPoints");
        Cam = GameObject.Find("Camera Pivot");
        _lerpScript = PuzzlePiece.GetComponentInChildren<ObjectLerpScript>();
        _camOffset = new Vector3(40, 0, 40);
        _progressBar = (GameObject)Resources.Load("CanvasTiny", typeof(GameObject));
    }

    private void Update()
    {


    }

    public void TogglePiece()
    {
        if (RequiredPiece == null)
        {
            Construction();
        }
        else if (RequiredPiece.GetComponent<PieceValueScript>().IsComplete)
        {
            Construction();
        }
        else
        {
            Debug.Log("Missing Requirement!");
            //ScoreSystem.GetComponent<ScoreSystemScript>().UpdatePoints(-10);
        }
    }

    public void Construction()
    {
        PieceValueScript pieceValueScript = PuzzlePiece.GetComponent<PieceValueScript>();

        if (!pieceValueScript.IsComplete)
        {
            if (!pieceValueScript.IsInProgress)
            {
                if (PuzzlePiece.activeInHierarchy)
                {
                    PuzzlePiece.SetActive(false);
                }
                else
                {
                    PuzzlePiece.SetActive(true);
                }
                StartCoroutine(StartBuilding(pieceValueScript.BuildingTime));
                pieceValueScript.IsInProgress = true;

                GameObject realProgressBar = Instantiate(_progressBar, (PuzzlePiece.transform.position + new Vector3(0, 10, 0)), Quaternion.identity);
                Cam.GetComponent<IsometricCam>().Trans = PuzzlePiece.transform.position + _camOffset;
                _lerpScript.SetDestination(pieceValueScript.BuildingTime);
                //hier animatie aanroepen
                //kun je met animator een tijdsparameter setten met code? want ding moet omhoog obv de buildingtime parameter

                realProgressBar.GetComponentInChildren<ProgresBarScript>().BuildTime = pieceValueScript.BuildingTime;
            }
        }
    }

    public IEnumerator StartBuilding(float buildingTime)
    {
        yield return new WaitForSeconds(buildingTime);

        PuzzlePiece.GetComponent<PieceValueScript>().IsComplete = true;
        PuzzlePiece.GetComponent<PieceValueScript>().IsInProgress = false;

        //ScoreSystem.GetComponent<ScoreSystemScript>().UpdatePoints(50);
    }

}
