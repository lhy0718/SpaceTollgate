using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public Text text;
    public Text scoreText;
    public Button retryButton;
    public PlayerController player;
    public Slider hpBar;
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

    void Awake() {
        instance = this;
        //text.SetActive(true);
    }

    void Start() {
        GameInit();
        retryButton.onClick.AddListener(delegate {
            SceneManager.LoadScene("Main");
        });
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
}
