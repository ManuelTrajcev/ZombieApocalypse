using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    [SerializeField] TMP_Text highscoreText;


    void Awake()
    {
        PlayerPrefs.SetFloat("CurrentScore", 0);
        startButton.onClick.AddListener(() => StartGame());
        quitButton.onClick.AddListener(() => QuitGame());
        highscoreText.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore", 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}