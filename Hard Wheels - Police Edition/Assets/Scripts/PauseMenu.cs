using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject controlsPanel;
    public GameObject areYouSureQuitPanel;
    public GameObject areYouSureRestartPanel;
    public GameObject backButton;

    public GameObject yesRestartButton;
    
    public GameObject noRestartButton;

    public GameObject yesQuitButton;
    public GameObject noQuitButton;

    public bool pauseButtonPressed = false;
    public bool f1input = false;
    public bool f2input = false;
    public bool esc = false;

    public void Start()
    {
        pauseMenuPanel.SetActive(false);
        controlsPanel.SetActive(false);
        areYouSureQuitPanel.SetActive(false);
        areYouSureRestartPanel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && !f2input && !esc) // Ελέγχει αν το F2 είναι ενεργοποιημένο και το F1 δεν είναι.
        {
            f1input = !f1input;
            controlsPanel.SetActive(f1input);
            Time.timeScale = f1input ? 0 : 1;
        }

        if (Input.GetKeyDown(KeyCode.F2) && !f1input && !esc) // Ελέγχει αν το F1 είναι ενεργοποιημένο και το F2 δεν είναι.
        {
            f2input = !f2input;
            Time.timeScale = f2input ? 0 : 1;
            Pause();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && !f1input && !f2input)
        {
            esc = !esc;
            areYouSureQuitPanel.SetActive(esc);
            Time.timeScale = esc ? 0 : 1;
        }
    }

    //Action Buttons
    public void BackButton()
    {
        f1input = false;
        controlsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pauseButtonPressed = !pauseButtonPressed;

        if (pauseButtonPressed)
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        f2input = false;
        esc = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
        pauseButtonPressed = !pauseButtonPressed;
    }

    public void Restart()
    {
        areYouSureRestartPanel.SetActive(true);
    }

    public void Quit()
    {
        areYouSureQuitPanel.SetActive(true);
    }


    //Yes & No Answers
    public void YesRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void NoRestart()
    {
        areYouSureRestartPanel.SetActive(false);
    }

    public void YesQuit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void NoQuit()
    {
        esc = false;
        areYouSureQuitPanel.SetActive(false);
    }

}
