using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static bool IS_PAUSED;

    static float INITIAL_TIME = 40;
    static int INITIAL_SCORE = 0;
    static GameManager _Instance;

    public GameObject m_GameOverPanel;
    public Button m_PauseButton;
    public GameObject m_PausePanel;
    public Text m_TimeDisplay;
    public Text m_ScoreDisplay;
    public Text m_FinalScore;
    public Text m_RecordText;

    int m_HighScore;
    float m_Time;
    int  m_Score;

    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<GameManager>();

            }
            return _Instance;
        }
    }

    private void Awake()
    {
        m_RecordText.gameObject.SetActive(false);
        m_Score = INITIAL_SCORE;
        m_ScoreDisplay.text = "Score: " + m_Score;
        m_Time = INITIAL_TIME;
        m_TimeDisplay.text = ""+INITIAL_TIME;
        IS_PAUSED = false;
        m_PauseButton.onClick.AddListener(PauseGame);
        m_HighScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log("HS:"+m_HighScore);
    }
    // Use this for initialization
    void Start () {
        m_ScoreDisplay.text = "Score: " + m_Score;

    }

    // Update is called once per frame
    void Update () {

        TimerCounter();
	}

    public void PauseGame()
    {
        Time.timeScale = 0f;
        IS_PAUSED = true;
        m_PausePanel.SetActive(true);

        m_PauseButton.onClick.RemoveAllListeners();
        m_PauseButton.onClick.AddListener(ResumeGame);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        IS_PAUSED = false;
        m_PausePanel.SetActive(false);
        m_PauseButton.onClick.RemoveAllListeners();
        m_PauseButton.onClick.AddListener(PauseGame);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

    }

    void TimerCounter()
    {
        if (m_Time <= 0)
        {
            GameOver();
        }
        else
        {
            m_Time = (m_Time - Time.deltaTime);
            m_TimeDisplay.text = "" + Mathf.RoundToInt(m_Time);
        }
    }

    public void IncreaseScore()
    {
        m_Score += 5;
        m_ScoreDisplay.text = "Score: " + m_Score;        
    }

    public void AddTime()
    {
        m_Time += 5;
        m_TimeDisplay.text = "" + m_Time;
    }

    public void GameOver()
    {
        StartCoroutine(DelayGameOver());
    }

    IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(1f);
        if (m_Score > m_HighScore)
        {
            PlayerPrefs.SetInt("HighScore", m_Score);
            m_RecordText.gameObject.SetActive(true);
        }
        m_FinalScore.text = "Score: "+m_Score;
        m_GameOverPanel.SetActive(true);

        Time.timeScale = 0f;
        Debug.Log("ACABOU");
    }
}
