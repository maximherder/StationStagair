using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    private Grid _grid;
    public GameObject SelectedItemPrefab;
    public GameObject Target;
    public ButtonManager ItemSelection;
    private bool _itemPreviewActive;

    // Start is called before the first frame update
    void Awake()
    {
        _grid = FindObjectOfType<Grid>();
        ItemSelection = FindObjectOfType<ButtonManager>();
        _itemPreviewActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SelectedItemPrefab = null;
        }
        if (ItemSelection.DestroyMode == false && SelectedItemPrefab != null)
        {
            CastRayAndPlace();
        }
    }

    public void ItemSet(GameObject item)
    {
        SelectedItemPrefab = item;
    }


    private void CastRayAndPlace()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo) && (hitInfo.collider.tag == "Floor"))
        {
            PlaceItemNear(hitInfo.point);
        }
    }

    private void PlaceItemNear(Vector3 NearPoint)
    {
        if (!_itemPreviewActive)
        {
            Vector3 finalPosition = _grid.GetNearestPointOnGrid(NearPoint);
            Target = Instantiate(SelectedItemPrefab, finalPosition, Quaternion.identity);
            _itemPreviewActive = true;
        }
        if (_itemPreviewActive && Target != null)
        {
            var collider = Target.GetComponent<Collider>();
            collider.enabled = false;
            
            Target.transform.position = _grid.GetNearestPointOnGrid(NearPoint);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _itemPreviewActive = false;
                SelectedItemPrefab = null;
                collider.enabled = true;
            }
        }
    }


}
