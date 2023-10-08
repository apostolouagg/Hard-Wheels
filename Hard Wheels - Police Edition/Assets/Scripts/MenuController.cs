using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject helpPanel;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    private string selectedDifficulty;

    public void Start()
    {
        mainPanel.SetActive(true);
        helpPanel.SetActive(false);
    }

    public void EasyDifficulty()
    {
        selectedDifficulty = "Easy";
        PlayerPrefs.SetString("Difficulty", selectedDifficulty);
        SceneManager.LoadScene("GameScene");
        // set the game difficulty to easy here
    }

    public void NormalDifficulty()
    {
        selectedDifficulty = "Normal";
        PlayerPrefs.SetString("Difficulty", selectedDifficulty);
        SceneManager.LoadScene("GameScene");
        // set the game difficulty to medium here
    }

    public void HardDifficulty()
    {
        selectedDifficulty = "Hard";
        PlayerPrefs.SetString("Difficulty", selectedDifficulty);
        SceneManager.LoadScene("GameScene");
        // set the game difficulty to hard here
    }

    public void BackButton()
    {
        mainPanel.SetActive(true);
        helpPanel.SetActive(false);
    }

    public void HelpButton()
    {
        Debug.Log("Help");
        // TODO: Add help code
        mainPanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
