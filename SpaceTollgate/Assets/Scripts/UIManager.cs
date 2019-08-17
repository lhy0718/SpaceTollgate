using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBehaviour<UIManager>
{
    public GameObject pausePanel;

    public GameObject upgradePanel;
    public Text ShieldCostText;
    public Text ShieldValueText;
    public Text RangeCostText;
    public Text RangeValueText;
    public Text SpeedCostText;
    public Text SpeedValueText;

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

    #region pause
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
    #endregion

    #region Upgrade
    public void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
        gm.GamePause();
    }
    public void CloseUpgradePanel()
    {
        upgradePanel.SetActive(false);
        gm.GameResume();
    }

    public void ShieldUpgrade()
    {
        Debug.Log("Upgrade Shield");
    }

    public void RangeUpgrade()
    {
        Debug.Log("Upgrade Range");
    }

    public void SpeedUpgrade()
    {
        Debug.Log("Upgrade Speed");
    }

    #endregion

}
