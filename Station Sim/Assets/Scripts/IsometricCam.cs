using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCam : MonoBehaviour
{
    public float CamSpeed;
    public float ScrollSpeed = 20;

    private Vector3 _origin;
    private Vector3 _difference;
    private bool _drag = false;
    private Vector3 _startPosition;
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
       // if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
           // PanCam();
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            ZoomCam();
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
            this.transform.position = (originVector - differenceVector) - _startPosition;
        }

        if (Input.GetKeyDown(KeyCode.R))
            ResetCam();
    }

    void PanCam()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        this.transform.Translate(input * CamSpeed * Time.deltaTime);
    }

    void ZoomCam()
    {
        float val = Camera.main.orthographicSize - ScrollSpeed * Input.GetAxisRaw("Mouse ScrollWheel");
        val = Mathf.Clamp(val, 20, 100);
        Camera.main.orthographicSize = val;
    }

    void ResetCam()
    {
        this.transform.position = new Vector3(0, 0, 0);
        Camera.main.orthographicSize = _camSize;
    }
}
