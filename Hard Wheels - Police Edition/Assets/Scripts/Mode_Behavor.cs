using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode_Behavor : MonoBehaviour
{
    public GameObject modePanel;
    public GameObject startPanel;
    public GameObject easyPanel;
    public GameObject normalPanel;
    public GameObject hardPanel;

    private void Start()
    {
        // Hide the easy, normal and hard mode panels initially
        easyPanel.SetActive(false);
        normalPanel.SetActive(false);
        hardPanel.SetActive(false);
    }

    public void OnModePanelClicked()
    {
        // Hide the mode panel and start panel
        modePanel.SetActive(false);
        startPanel.SetActive(false);

        // Show the easy, normal and hard mode panels
        easyPanel.SetActive(true);
        normalPanel.SetActive(true);
        hardPanel.SetActive(true);
    }
}
