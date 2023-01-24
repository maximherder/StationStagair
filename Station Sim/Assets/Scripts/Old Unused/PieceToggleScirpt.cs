using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceToggleScirpt : MonoBehaviour
{
    private GameObject currentObject;
    [SerializeField] private float TransparantAlpha = 0.4f;
    [SerializeField] private float OpaqueAlpha = 1f;
    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
        currentObject = gameObject;
        _isActive = true;
    }

    private void OnMouseDown()
    {
        if (_isActive)
        {
            ChangeAlpha(currentObject.GetComponent<Renderer>().material, TransparantAlpha);
            _isActive = false;
        }
        else
        {
            ChangeAlpha(currentObject.GetComponent<Renderer>().material, OpaqueAlpha);
            _isActive = true;
        }
    }

    private void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
