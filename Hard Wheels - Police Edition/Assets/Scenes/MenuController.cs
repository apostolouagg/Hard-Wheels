using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject difficultyPanel;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        difficultyPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ChooseDifficulty()
    {
        mainMenuPanel.SetActive(false);
        difficultyPanel.SetActive(true);
    }

    public void HelpButton()
    {
        Debug.Log("Help");
        // TODO: Add help code
    }

    public void EasyDifficulty()
    {
        SceneManager.LoadScene("GameScene");
        // set the game difficulty to easy here
    }

    public void NormalDifficulty()
    {
        SceneManager.LoadScene("GameScene");
        // set the game difficulty to medium here
    }

    public void HardDifficulty()
    {
        SceneManager.LoadScene("GameScene");
        // set the game difficulty to hard here
    }

    public void BackToMainMenu()
    {
        Debug.Log("Back");
        mainMenuPanel.SetActive(true);
        difficultyPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
