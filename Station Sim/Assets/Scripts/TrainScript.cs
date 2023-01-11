using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainScript : MonoBehaviour
{
    //public Animator Train;
    public GameObject Train;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TrainAction();
        }
    }

    public void TrainAction()
    {
        Train.GetComponent<Animator>().Play("Train_In");
    }
}
