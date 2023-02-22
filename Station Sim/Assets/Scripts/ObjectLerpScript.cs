using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLerpScript : MonoBehaviour
{
    private float t;
    private Vector3 _startPosition;
    private Vector3 _target;
    private float _timeToReachTarget;

    void Update()
    {
        t += Time.deltaTime / _timeToReachTarget;
        transform.position = Vector3.Lerp(_startPosition, _target, t);
    }
    public void SetDestination(float time)
    {
        t = 0;
        _startPosition = transform.position;
        _timeToReachTarget = time;
        _target = new Vector3(_startPosition.x, 0, _startPosition.z);
    }
}
