using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresBarScript : MonoBehaviour
{
    public int Max;
    public int Current;
    public Image Mask;
    public float BuildTime;
    private bool _inProgress;

    // Start is called before the first frame update
    void Start()
    {
        Mask.fillAmount = 0;
        _inProgress = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetFillAmount();
    }

    void GetFillAmount()
    {
        if (_inProgress)
        {
            Mask.fillAmount += (1.0f / BuildTime) * Time.deltaTime;
            if (Mask.fillAmount >= 1)
            {
                _inProgress = false;
            }
        }
    }

}
