using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLerpScript : MonoBehaviour
{
    public bool Move = false;
    private float t;
    private Vector3 _startPosition;
    private Vector3 _target;
    private float _timeToReachTarget;

    void Update()
    {
        if (Move)
        {
            t += Time.deltaTime / _timeToReachTarget;
            transform.position = Vector3.Lerp(_startPosition, _target, t);
            if (transform.position.y == _target.y)
            {
                Move = false;
            }
        }
    }
    public void SetDestination(float time, bool up)
    {
        t = 0;
        _startPosition = transform.position;
        _timeToReachTarget = time;
        if (up)
            _target = new Vector3(_startPosition.x, 0, _startPosition.z);
        else
            _target = new Vector3(_startPosition.x, -10, _startPosition.z);

    }


}
