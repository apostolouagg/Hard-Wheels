using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject briefPanel;
    public GameObject levelPanel;
    public GameObject controlsPanel;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    private string selectedDifficulty;

    public void Start()
    {
        mainPanel.SetActive(true);
        levelPanel.SetActive(false);
        briefPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void playButton()
    {

    }

    public void EasyDifficulty()
    {
        selectedDifficulty = "Easy";
        PlayerPrefs.SetString("Difficulty", selectedDifficulty);
        // set the game difficulty to easy here
    }

    public void NormalDifficulty()
    {
        selectedDifficulty = "Normal";
        PlayerPrefs.SetString("Difficulty", selectedDifficulty);
        // set the game difficulty to medium here
    }

    public void HardDifficulty()
    {
        selectedDifficulty = "Hard";
        PlayerPrefs.SetString("Difficulty", selectedDifficulty);
        // set the game difficulty to hard here
    }

    public void levelsButton()
    {

    }

    public void xButton()
    {

    }

    public void controlsButton()
    {
        briefPanel.SetActive(false);
        mainPanel.SetActive(false);
        levelPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void BackButton()
    {
        mainPanel.SetActive(true);
        levelPanel.SetActive(false);
        briefPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    //brief button
    public void BriefButton()
    {
        Debug.Log("Help");
        // TODO: Add help code
        briefPanel.SetActive(true);
        mainPanel.SetActive(false);
        levelPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }



    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
