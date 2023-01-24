using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // button functionality
    public GameObject ItemPlacer;
    public GameObject SelectedItem;
    public List<GameObject> ItemPrefabs;
    public bool DestroyMode;
    public bool BuildMode;
    private GameObject buildPanel;
    private GameObject controlsPanel;
    private bool _controlPanelActive;

    void Awake()
    {
        DestroyMode = false;
        BuildMode = false;
        buildPanel = GameObject.Find("BuildPanel");
        controlsPanel = GameObject.Find("ControlsPanelExposed");
        controlsPanel.SetActive(false);
        _controlPanelActive = false;
    }

    public void SetItemToCube()
    {
        SelectedItem = ItemPrefabs[0];
        ItemPlacer.GetComponent<ItemPlacer>().ItemSet(SelectedItem);
    }

    public void SetItemToSphere()
    {
        SelectedItem = ItemPrefabs[1];
        ItemPlacer.GetComponent<ItemPlacer>().ItemSet(SelectedItem);
    }

    public void SetItemToFloor()
    {
        SelectedItem = ItemPrefabs[3];
        ItemPlacer.GetComponent<ItemPlacer>().ItemSet(SelectedItem);
    }

    public void ToggleDestroyMode()
    {
        DestroyMode = !DestroyMode;
        if (DestroyMode)
        {
            buildPanel.SetActive(false);
        }
    }

    public void ToggleBuildMode()
    {
        BuildMode = !BuildMode;

        if (!BuildMode)
        {
            buildPanel.SetActive(false);
        }
        else if (BuildMode)
        {
            DestroyMode = false;
            buildPanel.SetActive(true);
        }
    }

    public void ToggleControlsPanel()
    {
        _controlPanelActive = !_controlPanelActive;

        if (_controlPanelActive)
        {
            controlsPanel.SetActive(true);
        }
        if (!_controlPanelActive)
        {
            controlsPanel.SetActive(false);
        }
    }

}
