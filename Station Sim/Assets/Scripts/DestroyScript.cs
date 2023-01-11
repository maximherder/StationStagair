using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public bool CanDestroy;


    private void Awake()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject itemSelection = GameObject.Find("ButtonManager");
        CanDestroy = itemSelection.GetComponent<ButtonManager>().DestroyMode;
        if (CanDestroy)
            Destroy(gameObject);
    }
}
