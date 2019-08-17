using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager> {
    //public static GameManager instance;

    public Text text;
    public Text scoreText;
    public Button retryButton;
    public PlayerController player;
    public Slider hpBar;
    public bool isPause = false;
    private int score;
    public int Score {
        get {
            return score;
        }
        set {
            score = value;
            scoreText.text = "Score : " + score;
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
        text.gameObject.SetActive(false);
        Score = 0;
        player.Hp = player.maxHp = 100;
        retryButton.gameObject.SetActive(false);
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
}
