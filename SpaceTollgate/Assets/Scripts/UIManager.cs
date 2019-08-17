using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBehaviour<UIManager>
{
    public GameObject pausePanel;
    private GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
            SetStatic();

        gm = GameManager.instance;
        //text.SetActive(true);
    }

    public void PauseGame()
    {
        gm.GamePause();
        OpenPausePanel();
        
    }
    public void ResumeGame()
    {
        gm.GameResume();
        ClosePausePanel();
    }
    private void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }
    private void ClosePausePanel()
    {
        pausePanel.SetActive(false);
    }
    
}
