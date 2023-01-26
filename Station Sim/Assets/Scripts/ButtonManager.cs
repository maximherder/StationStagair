using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private GameObject controlsPanel;
    private bool _controlPanelActive;


    void Awake()
    {
        controlsPanel = GameObject.Find("ControlsPanelExposed");
        controlsPanel.SetActive(false);
        _controlPanelActive = false;
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
