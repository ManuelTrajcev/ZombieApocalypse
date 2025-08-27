using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;  // Reference to the player
    [SerializeField] private MonoBehaviour[] playerScripts;  // List of player scripts to disable
    FirstPersonController _firstPersonController;
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text scoreWonText;
    [SerializeField] TMP_Text timeBonusText;
    [SerializeField] GameObject youWonUI;
    private int _enemiesLeft = 0;
    private int _score = 0;
    private float _timeBonus = 0;
    private float _startTime;
    private const string ENEMIES_LEFT_STRING = "Enemies left: ";
    private const string SCORE_STRING = "Score: ";


    void Start()
    {
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
            scoreWonText.text = SCORE_STRING + _score.ToString();
            timeBonusText.text = timeBonusText.text + _timeBonus.ToString();
            youWonUI.SetActive(true);
            DisablePlayerInput();
            StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssetsInputs.SetCursorState(false);
            starterAssetsInputs.shoot = false;
        }
    }
    
    public void AdjustScoreText(int amount)
    {
        _score += amount;

        scoreText.text = SCORE_STRING + _score.ToString();
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
    
    private bool isInputDisabled = false;

    // Call this when you want to disable player input
    public void DisablePlayerInput()
    {
        if (!isInputDisabled)
        {
            // Disable player input scripts
            foreach (var script in playerScripts)
            {
                script.enabled = false;
            }
            
            _firstPersonController.DisablePlayerInput();
            
            // Optionally disable player movement or camera scripts if needed
            if (player != null)
                player.GetComponent<CharacterController>().enabled = false; // If you're using CharacterController for movement

            if (GetComponent<Camera>() != null)
                GetComponent<Camera>().GetComponent<Camera>().enabled = false;  // Disable camera if needed

            isInputDisabled = true;
        }
    }

    // Call this when you want to re-enable player input
    public void EnablePlayerInput()
    {
        if (isInputDisabled)
        {
            // Re-enable player input scripts
            foreach (var script in playerScripts)
            {
                script.enabled = true;
            }
            
            _firstPersonController.EnablePlayerInput();
            
            // Re-enable player movement or camera scripts if needed
            if (player != null)
                player.GetComponent<CharacterController>().enabled = true;

            if (GetComponent<Camera>() != null)
                GetComponent<Camera>().GetComponent<Camera>().enabled = true;

            isInputDisabled = false;
        }
    }
}
