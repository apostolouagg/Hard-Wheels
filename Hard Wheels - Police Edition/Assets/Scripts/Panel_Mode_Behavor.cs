using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject easyModePanel;
    public GameObject normalModePanel;
    public GameObject hardModePanel;

    private void Start()
    {
        // Disable all game mode panels on start
        easyModePanel.SetActive(false);
        normalModePanel.SetActive(false);
        hardModePanel.SetActive(false);
    }

    public void OnSelectModeButtonClick()
    {
        // Hide the start panel
        startPanel.SetActive(false);

        // Show the game mode panels
        easyModePanel.SetActive(true);
        normalModePanel.SetActive(true);
        hardModePanel.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        // Show the start panel
        startPanel.SetActive(true);

        // Hide the game mode panels
        easyModePanel.SetActive(false);
        normalModePanel.SetActive(false);
        hardModePanel.SetActive(false);
    }
}
