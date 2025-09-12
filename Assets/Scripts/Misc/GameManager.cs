using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    FirstPersonController _firstPersonController;
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text scoreWonText;
    [SerializeField] TMP_Text timeBonusText;
    [SerializeField] GameObject youWonUI;
    private int _enemiesLeft = 0;
    private float _currentLevelScore = 0;
    private float _timeBonus = 0;
    private float _startTime;
    private const string ENEMIES_LEFT_STRING = "Enemies left: ";
    private const string SCORE_STRING = "Score: ";
    private const string TIME_BONUS_STRING = "Time Bonus: +";
    private bool _isInputDisabled = false;
    List<int> allLevelsScores = new List<int>();

    void Start()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        allLevelsScores[currentScene] = 0;
        EnablePlayerInput();
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(true);
        _startTime = Time.time;
        _firstPersonController = player.GetComponent<FirstPersonController>();
    }

    public void AdjustEnemiesLeft(int amount)
    {
        _enemiesLeft += amount;
        if (amount < 0)
        {
            AdjustScoreText(10);
        }

        enemiesLeftText.text = ENEMIES_LEFT_STRING + _enemiesLeft.ToString();
        if (_enemiesLeft <= 0)
        {
            float elapsedTime = Time.time - _startTime;
            _timeBonus = Mathf.Max(0f, Mathf.Log(1000f + 1) - Mathf.Log(elapsedTime + 1));
            _timeBonus *= 2.8f;
            scoreWonText.text = SCORE_STRING + _currentLevelScore.ToString();
            timeBonusText.text = TIME_BONUS_STRING + _timeBonus.ToString();
            youWonUI.SetActive(true);
            _currentLevelScore += _timeBonus;

            PlayerPrefs.SetFloat("CurrentScore", PlayerPrefs.GetFloat("CurrentScore", 0) + _currentLevelScore);

            var prevHighScore = PlayerPrefs.GetFloat("Highscore", 0);
            var newScore = PlayerPrefs.GetFloat("CurrentScore", 0);

            if (newScore > prevHighScore)
            {
                PlayerPrefs.SetFloat("Highscore", _currentLevelScore);
                PlayerPrefs.Save();
            }

            DisablePlayerInput();
            StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssetsInputs.shoot = false;
        }
    }

    public void AdjustScoreText(int amount)
    {
        _currentLevelScore += amount;

        scoreText.text = SCORE_STRING + _currentLevelScore.ToString();
        if (_enemiesLeft <= 0)
        {
            youWonUI.SetActive(true);
        }
    }

    public void QuitButton()
    {
        Debug.LogWarning("Quit");
        Application.Quit();
    }

    public void RestartButton()
    {
        Debug.LogWarning("Restart");
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void NextLevelButton()
    {
        Debug.LogWarning("NextLevel");
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Total scenes: " + SceneManager.sceneCount);
        if (SceneManager.sceneCount > currentScene + 1)
        {
            SceneManager.LoadScene(currentScene + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void DisablePlayerInput()
    {
        if (!_isInputDisabled)
        {
            StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssetsInputs.SetCursorState(false);
            _firstPersonController.DisablePlayerInput();

            if (player != null)
                player.GetComponent<CharacterController>().enabled = false;

            if (GetComponent<Camera>() != null)
                GetComponent<Camera>().GetComponent<Camera>().enabled = false;

            _isInputDisabled = true;
        }
    }

    public void EnablePlayerInput()
    {
        if (_isInputDisabled)
        {
            _firstPersonController.EnablePlayerInput();

            if (player != null)
                player.GetComponent<CharacterController>().enabled = true;

            if (GetComponent<Camera>() != null)
                GetComponent<Camera>().GetComponent<Camera>().enabled = true;

            _isInputDisabled = false;
        }
    }
}