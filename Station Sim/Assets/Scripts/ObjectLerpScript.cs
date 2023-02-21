using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLerpScript : MonoBehaviour
{
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;

    void Update()
    {
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, target, t);
    }
    public void SetDestination(float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = new Vector3(startPosition.x, 0, startPosition.z);
    }
}
