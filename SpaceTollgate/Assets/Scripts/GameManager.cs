using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager> {
    //public static GameManager instance;

    public new Camera camera;
    public Text text;
    public Text scoreText;
    public Button retryButton;
    public Button startButton;
    public PlayerController player;
    public Slider hpBar;
    public bool isPause = false;

    public float playTime;

    public int[] ShieldCost= {20,30};
    //public int[] ShieldValue= {20,30};
    public int[] RangeCost= {20,30};
    //public int[] RangeValue= {20,30};
    public int[] SpeedCost= {20,30};
    //public int[] SpeedValue= {20,30};


    private int score;
    public int Score {
        get {
            return score;
        }
        set {
            score = value;
            scoreText.text = ": " + score;
        }
    }
    void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
            SetStatic();
        //text.SetActive(true);
    }

    void Start() {
        GameInit();
        retryButton.onClick.AddListener(delegate {
            SceneManager.LoadScene("Main");
        });
    }
    void Update()
    {
        playTime += Time.deltaTime;
        UIManager.instance.updatePlayTime(playTime);
        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void GameInit() {
        camera.orthographicSize = 5;
        text.gameObject.SetActive(false);
        //for Test
        Score = 2000;
        player.Hp = player.maxHp = 100;
        player.ShieldLevel = 0;
        player.RangeLevel = 0;
        player.SpeedLevel = 0;
        retryButton.gameObject.SetActive(false);
        playTime = 0f;
    }

    public void GameOver() {
        text.gameObject.SetActive(true);
        text.text = "GAME OVER";
        retryButton.gameObject.SetActive(true);
    }

    public void GamePause()
    {
        isPause = true;
    }

    public void GameResume()
    {
        isPause = false;
    }

    public void UpgradePlayerLevel(int statusNumber)
    {
        if (statusNumber == 0)
        {
            player.ShieldLevel++;
        }
        else if (statusNumber == 1)
        {
            player.RangeLevel++;
        }
        else if (statusNumber == 2)
        {
            player.SpeedLevel++;
        }
    }
    
}
