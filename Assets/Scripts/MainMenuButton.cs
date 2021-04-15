using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public GameObject ControlsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OpenPanel()
    {
        if(ControlsPanel != null)
        {
            bool isActive = ControlsPanel.activeSelf;
            ControlsPanel.SetActive(!isActive);
        }
    }

}
