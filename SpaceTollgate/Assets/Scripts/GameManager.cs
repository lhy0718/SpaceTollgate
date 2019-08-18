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

    public PlayerController player;
    public Slider hpBar;
    public bool isPause = false;

    public bool isTimeStage;
    public float playTime;
    public float limitPlayTime;
    public int[] monsterCnt;
    public int[] monsterQuest;

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
            scoreText.text = "Gold : " + score;
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
        CheckWinCondition();
    }

    private void GameInit() {
        camera.orthographicSize = 5;
        text.gameObject.SetActive(false);
        //for Test
        Score = 1000;
        player.Hp = player.maxHp = 100;
        retryButton.gameObject.SetActive(false);
        playTime = 0f;

        for(int i = 0; i < monsterCnt.Length; i++)
        {
            monsterCnt[i] = 0;
        }
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

    public void GameClear()
    {
        //GamePause();
        //UIManager.instance.OpenClearPanel();
        Debug.Log("gameClear!");
    }

    /*
    public void UpgradePlayerLevel()
    {
        Debug.Log("Upgrade Player Level");
        //player level에 프로퍼티를 달아서 능력치를 조정하자. 
    }
    */

    public void CheckWinCondition()
    {
        if (isTimeStage)
        {
            if (limitPlayTime <= playTime)
            {
                GameClear();
            }
        }
        else
        {
            bool isClear = true;
            for(int i = 0; i < monsterCnt.Length; i++)
            {
                isClear=isClear && monsterCnt[i] >= monsterQuest[i];
            }
            if (isClear)
                GameClear();
        }
    }
}
