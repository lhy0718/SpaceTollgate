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
        Debug.Log("Upgrade Shield");
        gm.Score -= gm.ShieldCost[0];
        UpdateInfo();
    }

    public void RangeUpgrade()
    {
        Debug.Log("Upgrade Range");
        gm.Score -= gm.RangeCost[0];
        UpdateInfo();
    }

    public void SpeedUpgrade()
    {
        Debug.Log("Upgrade Speed");
        gm.Score -= gm.SpeedCost[0];
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        ShieldCostText.text=": -"+gm.ShieldCost[0];
        ShieldValueText.text=": +1";
        RangeCostText.text = ": -" + gm.RangeCost[0];
        RangeValueText.text = ": +2";
        SpeedCostText.text = ": -" + gm.SpeedCost[0];
        //temp value
        SpeedValueText.text = ": +1.5";

        if(gm.ShieldCost[0]>gm.Score/*||player level > 6*/)
        {
            ShieldUpgradeButton.interactable=false;
        }
        if (gm.RangeCost[0] > gm.Score/*||player level > 5*/)
        {
            RangeUpgradeButton.interactable = false;
        }
        if (gm.SpeedCost[0] > gm.Score/*||player level > 7*/)
        {
            SpeedUpgradeButton.interactable = false;
        }
    }
    #endregion

}
