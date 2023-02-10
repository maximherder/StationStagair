using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCam : MonoBehaviour
{
    public float CamSpeed;
    public float ScrollSpeed = 20;
    public Vector3 Trans;

    private Vector3 _origin;
    private Vector3 _difference;
    private Vector3 _startPosition;
    private bool _drag = false;
    private float _camSize;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = new Vector3(-20, 0, -65);
        _camSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            ZoomCam();
        transform.position = Vector3.Lerp(transform.position, Trans, 1.0f * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
            if (_drag == false)
            {
                _drag = true;
                _origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            _drag = false;
        }

        if (_drag)
        {
            Vector3 originVector = new Vector3(_origin.x, 0, _origin.z);
            Vector3 differenceVector = new Vector3(_difference.x, 0, _difference.z);
            transform.position = (originVector - differenceVector) - _startPosition;
            Trans = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.R))
            ResetCam();
    }

    void ZoomCam()
    {
        float val = Camera.main.orthographicSize - ScrollSpeed * Input.GetAxisRaw("Mouse ScrollWheel");
        val = Mathf.Clamp(val, 20, 120);
        Camera.main.orthographicSize = val;
    }

    void ResetCam()
    {
        this.transform.position = new Vector3(0, 0, 0);
        Camera.main.orthographicSize = _camSize;
    }
}
