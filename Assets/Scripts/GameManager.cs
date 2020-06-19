using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int score = 0;

    public int beatLevelScore;

    public Text scoreText;
    public Text mainTimerDisplay;

    public float startTime = 20.0f;

    public GameObject gameOverOutline;
    public GameObject beatLevelOutline;

    private float currentTime;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0; // VSync must be disabled.
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        beatLevelScore = Mathf.Clamp(beatLevelScore, 1, int.MaxValue);
        score = Mathf.Clamp(score, 0, int.MaxValue);
        currentTime = startTime;
        if (gm == null)
            gm = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScore(int score)
    {
        this.score += score;
        scoreText.text = "x " + score.ToString();
    }
}
