using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtons : MonoBehaviour
{
    //public List<GameObject> PuzzlePieces;
    public GameObject PuzzlePiece;
    public GameObject RequiredPiece;
    public GameObject ScoreSystem;
    private GameObject _progressBar;
    public GameObject Cam;
    private Vector3 _camOffset;


    private void Start()
    {
        ScoreSystem = GameObject.Find("txtPoints");
        _camOffset = new Vector3(40, 0, 40);
        Cam = GameObject.Find("Camera Pivot");
        _progressBar = (GameObject)Resources.Load("CanvasTiny", typeof(GameObject));
    }

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
            //ScoreSystem.GetComponent<ScoreSystemScript>().UpdatePoints(-10);
            //popup here
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

                GameObject realProgressBar = Instantiate(_progressBar, PuzzlePiece.transform.position, Quaternion.identity);
                Cam.transform.position = PuzzlePiece.transform.position + _camOffset;
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
