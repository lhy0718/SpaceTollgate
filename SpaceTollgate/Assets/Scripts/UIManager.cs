using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBehaviour<UIManager>
{
    public GameObject pausePanel;
    public GameObject clearPanel;

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

    public Text playTimer;

    private GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != this) {
            Destroy(gameObject);
            return;
        }
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

    #region Game Clear
    public void OpenClearPanel()
    {
        clearPanel.SetActive(true);
    }
    public void ToStageSelectScene()
    {
        Debug.Log("To stage Select");
        MainSound.inst.GetComponent<AudioSource>().Play();
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
        gm.player.ShieldLevel++;
        UpdateInfo();
    }

    public void RangeUpgrade()
    {
        gm.Score -= gm.RangeCost[gm.player.RangeLevel];
        gm.player.RangeLevel++;
        UpdateInfo();
    }

    public void SpeedUpgrade()
    {
        gm.Score -= gm.SpeedCost[gm.player.SpeedLevel];
        gm.player.SpeedLevel++;
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        if (gm.player.ShieldLevel < 6)
        {
            ShieldCostText.text = ": -" + gm.ShieldCost[gm.player.ShieldLevel];
            ShieldValueText.text = ": +10";
            if (gm.ShieldCost[gm.player.ShieldLevel] > gm.Score)
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
            RangeValueText.text = ": +1.5";
            if (gm.RangeCost[gm.player.RangeLevel] > gm.Score)
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
            SpeedValueText.text = ": +2";
            if (gm.SpeedCost[gm.player.SpeedLevel] > gm.Score)
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

    #region Play Time
    public void updatePlayTime(float playtime)
    {
        string minutes = ((int)playtime / 60).ToString("00");
        string seconds = (playtime % 60).ToString("00");
        playTimer.text = minutes + ":" + seconds;
    }
    #endregion

}
