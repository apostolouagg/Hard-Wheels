using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject Panel_Start;
    public GameObject Panel_Easy;
    public GameObject Panel_Normal;
    public GameObject Panel_Hard;

    private void Start()
    {
        // Disable all game mode panels on start
        Panel_Easy.SetActive(false);
        Panel_Normal.SetActive(false);
        Panel_Hard.SetActive(false);
    }

    public void OnSelectModeButtonClick()
    {
        // Hide the start panel
        Panel_Start.SetActive(false);

        // Show the game mode panels
        Panel_Easy.SetActive(true);
        Panel_Normal.SetActive(true);
        Panel_Hard.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        // Show the start panel
        Panel_Start.SetActive(true);

        // Hide the game mode panels
        Panel_Easy.SetActive(false);
        Panel_Normal.SetActive(false);
        Panel_Hard.SetActive(false);
    }
}
