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

    /* Hier hadden we het al even kort over gehad, dit zou je ook kunnen doen door een list te maken (wanneer alles in een bepaalde volgorde moet ten minste.
     * Dan zou je requiredpiece niet meer nodig hebben en de if check die je nu gebruikt voor de eerste stap ook niet.
     */
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
                if (PuzzlePiece.activeInHierarchy) // flip je de bool altijd? Dan zou je het ook zo kunnen doen: PuzzlePiece.SetActive(!PuzzlePiece.activeInHierarchy) Als je het op deze manier leesbaarder vind is dit ook helemaal oke.
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
                realProgressBar.GetComponentInChildren<ProgresBarScript>().BuildTime = pieceValueScript.BuildingTime; // Dit is persoonlijke voorkeur maar ik zou deze regel en die hierboven omdraaien.
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
