using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject briefPanel;
    public GameObject levelsPanel;
    public GameObject controlsPanel;
    public GameObject loadingPanel;
    public GameObject MenuBackground2;
    public GameObject MenuBackground3;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    private string selectedDifficulty;
    public bool levelsIsOpen;
    public bool controlsIsOpen;
    public bool briefIsOpen;

    public void Start()
    {
        mainPanel.SetActive(true);
        levelsPanel.SetActive(false);
        briefPanel.SetActive(false);
        controlsPanel.SetActive(false);
        MenuBackground2.SetActive(false);
        MenuBackground3.SetActive(false);
        loadingPanel.SetActive(false);
    }

    public void EasyDifficulty()
    {
        selectedDifficulty = "Easy";
        PlayerPrefs.SetString("Difficulty", selectedDifficulty);
        xButton();
        // set the game difficulty to easy here
    }

    public void NormalDifficulty()
    {
        selectedDifficulty = "Normal";
        PlayerPrefs.SetString("Difficulty", selectedDifficulty);
        xButton();
        // set the game difficulty to medium here
    }

    public void HardDifficulty()
    {
        selectedDifficulty = "Hard";
        PlayerPrefs.SetString("Difficulty", selectedDifficulty);
        xButton();
        // set the game difficulty to hard here
    }

    //animation
    public void levelsButton()
    {
        mainPanel.SetActive(true);
        briefPanel.SetActive(false);
        controlsPanel.SetActive(false);
        levelsPanel.SetActive(true);

        levelsIsOpen = isOpen(levelsIsOpen, levelsPanel);
    }

    public void xButton()
    {
        if (!levelsIsOpen)
        {
            levelsIsOpen = isOpen(levelsIsOpen, levelsPanel);
        }

        mainPanel.SetActive(true);
        briefPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void controlsButton()
    {
        MenuBackground3.SetActive(false);
        briefPanel.SetActive(false);
        mainPanel.SetActive(false);
        levelsPanel.SetActive(false);
        controlsPanel.SetActive(true);

        controlsIsOpen = isOpen(controlsIsOpen, controlsPanel);
    }

    //brief button
    public void BriefButton()
    {   
        MenuBackground2.SetActive(false);
        controlsPanel.SetActive(false);
        mainPanel.SetActive(false);
        levelsPanel.SetActive(false);
        briefPanel.SetActive(true);

        briefIsOpen = isOpen(briefIsOpen, briefPanel);
    }

    public void BackButton()
    {
        if (!controlsIsOpen)
        {
            MenuBackground3.SetActive(true);
            controlsIsOpen = isOpen(controlsIsOpen, controlsPanel);

            mainPanel.SetActive(true);
            levelsPanel.SetActive(false);
            briefPanel.SetActive(false);
        }
    }

    public void BackButton2()
    {
        if (!briefIsOpen)
        {
            MenuBackground2.SetActive(true);
            briefIsOpen = isOpen(briefIsOpen, briefPanel);

            mainPanel.SetActive(true);
            levelsPanel.SetActive(false);
            controlsPanel.SetActive(false);
        }
    }

    public bool isOpen(bool state, GameObject panel)
    {
        if (panel != null)
        {
            Animator animator = panel.GetComponent<Animator>();

            if (animator != null)
            {
                state = animator.GetBool("open");
                animator.SetBool("open", !state);
            }
        }

        return state;
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
