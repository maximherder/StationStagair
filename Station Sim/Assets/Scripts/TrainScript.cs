using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainScript : MonoBehaviour
{
    public GameObject Train;
    private GameObject _instantiatedTrain;
    private bool _trainReady = true;
    public bool Decommissioned = false;

    private void Start()
    {
        SpawnTrain();
    }

    private void Update()
    {
        if (!Decommissioned)
        {
            if (_trainReady)
                StartCoroutine(TrainDelay());
        }
        else
            Destroy(_instantiatedTrain);
    }

    private IEnumerator TrainDelay()
    {
        _trainReady = false;
        yield return new WaitForSeconds(15);
        if (_instantiatedTrain != null)
        {
            Destroy(_instantiatedTrain);
        }
        yield return new WaitForSeconds(6);
        SpawnTrain();
    }

    private void SpawnTrain()
    {
        _instantiatedTrain = Instantiate(Train, new Vector3(0, 0, 0), Quaternion.identity);
        _instantiatedTrain.GetComponent<Animator>().Play("Train West");
        _trainReady = true;
    }


}
