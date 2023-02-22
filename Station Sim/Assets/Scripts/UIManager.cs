using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject ControlsPanel;
    public GameObject ChoicePanel;
    public TextMeshProUGUI ChoiceText;

    private bool _controlPanelActive;
    private CanvasGroup _canvasGroup;
    private bool _choicePanelActive;

    void Awake()
    {
        ControlsPanel.SetActive(false);
        _controlPanelActive = false;

        _canvasGroup = ChoicePanel.GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        _choicePanelActive = false;
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

    public void UpdateChoicePanel(GameObject panel)
    {
        
    }

    //update and toggle de choice panels in deze class

}
