using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject ControlsPanel;
    public GameObject ChoicePanel;
    public GameObject EndScreen;
    public TextMeshProUGUI Panel1;
    public TextMeshProUGUI Panel2;
    public GameObject DecommissionBorder;

    private bool _controlPanelActive;
    private bool _choicePanelActive;
    private bool _borderActive;
    private CanvasGroup _canvasGroup;

    void Awake()
    {
        ControlsPanel.SetActive(false);
        DecommissionBorder.SetActive(false);
        EndScreen.SetActive(false);
        _controlPanelActive = false;

        _canvasGroup = ChoicePanel.GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        _choicePanelActive = false;
        _borderActive = false;
}


    public void ToggleControlsPanel()
    {
        _controlPanelActive = !_controlPanelActive;

        if (_controlPanelActive)
        {
            ControlsPanel.SetActive(true);
        }
        if (!_controlPanelActive)
        {
            ControlsPanel.SetActive(false);
        }
    }

    public void ToggleChoicePanel()
    {
        //simpele animatie dat ie omhoog en omlaag schuift (met unity's animatie ding, niet lerp ffs)

        _choicePanelActive = !_choicePanelActive;

        if (_choicePanelActive)
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
            //_choicePanel.SetActive(true);
        }
        if (!_choicePanelActive)
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = false;
        }
    }

    public void ToggleDecommissionBorder()
    {
        _borderActive = !_borderActive;

        if (_borderActive)
        {
            DecommissionBorder.SetActive(true);
        }
        if (!_borderActive)
        {
            DecommissionBorder.SetActive(false);
        }
    }

    public void UpdateChoicePanels(string choiceText1, string choiceText2)
    {
        Panel1.text = choiceText1;
        Panel2.text = choiceText2;
    }

    public void DisplayEndResults()
    {
        EndScreen.SetActive(true);
        //enable score panel that contains score and a button to quit, and a button to restart, and a button to go back to the main menu
    }

    //update and toggle de choice panels in deze class

}
