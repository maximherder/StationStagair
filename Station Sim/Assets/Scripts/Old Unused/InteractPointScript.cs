using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPointScript : MonoBehaviour
{
    private GameObject _interactUI;
    // Start is called before the first frame update
    void Start()
    {
        _interactUI = GameObject.Find("InteractPanel");
        Debug.Log("panel found");
        _interactUI.SetActive(false);
    }

    private void OnMouseDown()
    {
        Debug.Log("interact point clicked");
        _interactUI.SetActive(true);
    }


    public void ButtonFunction()
    {
        _interactUI.SetActive(false);
    }
}
