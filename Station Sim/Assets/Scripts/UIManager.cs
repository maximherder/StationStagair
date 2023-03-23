using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject ControlsPanel;
    public GameObject ChoicePanel;
    public GameObject EndScreen;
    public TextMeshProUGUI Panel1;
    public TextMeshProUGUI Panel2;
    public TextMeshProUGUI RankText;
    public TextMeshProUGUI ScoreText;
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

    //Called by clicking on the "Controls" button (bottom left of screen)
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
    }

    //Called by the Reset Button in the EndScreen Panel
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Called by the Menu Button in the EndScreen Panel
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateScore(int score, string rank)
    {
        ScoreText.text = "Score: " + score.ToString();
        RankText.text = "Rank: " + rank;
    }
}
