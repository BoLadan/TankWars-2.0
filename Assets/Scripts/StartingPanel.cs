using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPanel : MonoBehaviour
{
    public GameObject StartPanel;
    [SerializeField]

    private void Awake()
    {
        StartPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OpenPanel()
    {
        if (StartPanel != null)
        {
            StartPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
