using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] Canvas[] dialogs;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }else{
                ContinueGame();
            }
        }
    }
    public void PauseGame()
    {
        foreach (Canvas dialog in dialogs)
        {
            dialog.enabled = false;
        }
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        //Disable scripts that still work while timescale is set to 0
    }
    public void PauseGameNoMenu()
    {
        Time.timeScale = 0;
        //Disable scripts that still work while timescale is set to 0
    }
    public void ContinueGame()
    {
        foreach (Canvas dialog in dialogs)
        {
            dialog.enabled = true; ;
        }
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
