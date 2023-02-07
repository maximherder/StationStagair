using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject _choicePanel;
    private bool _controlPanelActive;
    private bool _choicePanelActive;


    void Awake()
    {
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

    public void ToggleChoicePanel()
    {
        _choicePanelActive = !_choicePanelActive;

        if (_choicePanelActive)
        {
            _choicePanel.SetActive(true);
        }
        if (!_controlPanelActive)
        {
            _choicePanel.SetActive(false);
        }
    }
}
