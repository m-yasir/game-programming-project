using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int score = 0;

    public int beatLevelScore;

    public Text scoreText;
    public Text mainTimerDisplay;

    public float startTime = 30.0f;

    public GameObject gameOverOutline;
    public GameObject beatLevelOutline;

    public bool isGameOver = false;

    private float currentTime;

    public string levelToLoad;

    public Texture2D cursor;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0; // VSync must be disabled.
        Application.targetFrameRate = 60;
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        if (gm == null)
            gm = gameObject.GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        beatLevelScore = Mathf.Clamp(beatLevelScore, 1, int.MaxValue);
        score = Mathf.Clamp(score, 0, int.MaxValue);
        scoreText.text = "x " + score.ToString();
        currentTime = startTime;
        beatLevelOutline.SetActive(false);
        gameOverOutline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        currentTime = Mathf.Clamp(currentTime - Time.deltaTime, 0, float.MaxValue);
        if (currentTime < 5.0f)
        {
            mainTimerDisplay.color = Color.red;
        }
        mainTimerDisplay.text = currentTime.ToString("0.00");

        if (score == beatLevelScore)
        {
            BeatLevel();
        }
        else if (currentTime == 0)
        {
            EndGame();
        }
    }

    public void BeatLevel()
    {
        isGameOver = true;
        mainTimerDisplay.color = Color.green;
        mainTimerDisplay.text = "Level Complete!";
        beatLevelOutline.SetActive(true);
    }

    public void EndGame()
    {
        isGameOver = true;
        mainTimerDisplay.text = "Game Over!";
        mainTimerDisplay.color = Color.red;
        gameOverOutline.SetActive(true);
    }

    public void addScore(int score)
    {
        this.score += score;
        scoreText.text = "x " + this.score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
