using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCam : MonoBehaviour
{
    public float CamSpeed;
    public float ScrollSpeed = 5;
    public float RotationAmount = 0.1f;
    public Camera ZoomCamObj;
    public GameObject PanCamObj;

    private Vector3 Origin;
    private Vector3 Difference;
    private bool drag = false;

    private Vector3 _startPosition;
    private float _camSize;
    private Vector3 _input;
    public Quaternion newRotation;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = new Vector3(-20, 0, -65);
        newRotation = transform.rotation;
        _camSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        PanCam();
        ZoomCam();
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            Vector3 originVector = new Vector3(Origin.x, 0, Origin.z);
            Vector3 differenceVector = new Vector3(Difference.x, 0, Difference.z);
            PanCamObj.transform.position = (originVector - differenceVector) - _startPosition;
        }

        if (Input.GetKeyDown(KeyCode.R))
            ResetCam();
    }

    void PanCam()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            PanCamObj.transform.Translate(_input * CamSpeed * Time.deltaTime);
        }
    }

    void ZoomCam()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (ZoomCamObj.orthographicSize > 5)
            {
                ZoomCamObj.orthographicSize -= ScrollSpeed;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (ZoomCamObj.orthographicSize < 100)
            {
                ZoomCamObj.orthographicSize += ScrollSpeed;
            }
        }
    }

    void ResetCam()
    {
        newRotation = Quaternion.identity;
        PanCamObj.transform.position = new Vector3(0, 0, 0);
        ZoomCamObj.orthographicSize = _camSize;
    }
}
