using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public GameObject PausePanel;

    private bool _gamePaused;

    private void Start()
    {
        PausePanel.SetActive(false);
        _gamePaused = false;
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

    public void ExitGame()
    {
        Application.Quit();
    }
}
