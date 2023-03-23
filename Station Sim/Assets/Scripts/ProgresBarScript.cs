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
    public GameObject Hammer;
    private GameObject _instantiatedHammer;
    private Vector3 _hammerOffset;

    // Start is called before the first frame update
    void Start()
    {
        _hammerOffset = new Vector3(20, 0, 0);
        Mask.fillAmount = 0;
        _instantiatedHammer = Instantiate(Hammer, transform.position + _hammerOffset, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        GetFillAmount();
    }

    void GetFillAmount()
    {
        Mask.fillAmount += (1.0f / BuildTime) * Time.deltaTime;
        if (Mask.fillAmount >= 1)
        {
            Destroy(gameObject);
            Destroy(_instantiatedHammer);
        }
    }

}
