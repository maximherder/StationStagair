using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{

    public GameObject PausePanel;
    public GameObject MainMenuRegular;
    public GameObject MainMenuSettings;
    public Slider VolumeSlider;

    private bool _gamePaused;
    private bool _settingsActive;

    private void Start()
    {
        if (PausePanel != null)
            PausePanel.SetActive(false);
        _gamePaused = false;
        _settingsActive = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        _gamePaused = !_gamePaused;

        if (_gamePaused)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        if (!_gamePaused)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //Called by clicking on the Exit button (top right of screen)
    //Called by clicking on Quit in the main menu
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleSettingsMenu()
    {
        _settingsActive = !_settingsActive;
        if (_settingsActive)
        {
            MainMenuRegular.SetActive(false);
            MainMenuSettings.SetActive(true);
        }
        else
        {
            MainMenuRegular.SetActive(true);
            MainMenuSettings.SetActive(false);
        }
    }

    public void ChangeVolumeSlider(float volume)
    {

    }
}
