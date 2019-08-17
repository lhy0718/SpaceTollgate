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
    public Button ShieldUpgradeButton;
    public Text RangeCostText;
    public Text RangeValueText;
    public Button RangeUpgradeButton;
    public Text SpeedCostText;
    public Text SpeedValueText;
    public Button SpeedUpgradeButton;

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
        UpdateInfo();
        gm.GamePause();
    }
    public void CloseUpgradePanel()
    {
        upgradePanel.SetActive(false);
        gm.GameResume();
    }

    public void ShieldUpgrade()
    {
        gm.Score -= gm.ShieldCost[gm.player.ShieldLevel];
        gm.UpgradePlayerLevel(0);
        UpdateInfo();
    }

    public void RangeUpgrade()
    {
        gm.Score -= gm.RangeCost[gm.player.RangeLevel];
        gm.UpgradePlayerLevel(1);
        UpdateInfo();
    }

    public void SpeedUpgrade()
    {
        gm.Score -= gm.SpeedCost[gm.player.SpeedLevel];
        gm.UpgradePlayerLevel(2);
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        if (gm.player.ShieldLevel < 6)
        {
            ShieldCostText.text = ": -" + gm.ShieldCost[gm.player.ShieldLevel];
            ShieldValueText.text = ": +1";
            if (gm.ShieldCost[gm.player.ShieldLevel + 1] > gm.Score)
            {
                ShieldUpgradeButton.interactable = false;
            }
        }
        else
        {
            ShieldCostText.text = ": ---";
            ShieldValueText.text = ": ---";
            ShieldUpgradeButton.interactable=false;
        }
        if (gm.player.RangeLevel < 5)
        {
            RangeCostText.text = ": -" + gm.RangeCost[gm.player.RangeLevel];
            RangeValueText.text = ": +1";
            if (gm.RangeCost[gm.player.RangeLevel + 1] > gm.Score)
            {
                RangeUpgradeButton.interactable = false;
            }
        }
        else
        {
            RangeCostText.text = ": ---";
            RangeValueText.text = ": ---";
            RangeUpgradeButton.interactable = false;
        }
        if (gm.player.SpeedLevel < 7)
        {
            SpeedCostText.text = ": -" + gm.SpeedCost[gm.player.SpeedLevel];
            SpeedValueText.text = ": +1";
            if (gm.SpeedCost[gm.player.SpeedLevel + 1] > gm.Score)
            {
                SpeedUpgradeButton.interactable = false;
            }
        }
        else
        {
            SpeedCostText.text = ": ---";
            SpeedValueText.text = ": ---";
            SpeedUpgradeButton.interactable = false;
        }

        
        
        
    }
    #endregion

}
