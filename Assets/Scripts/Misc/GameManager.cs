using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWonUI;
    private int enemiesLeft = 0;
    const string ENEMIES_LEFT_STRING = "Enemies left: ";

    public void AdjustEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();
        if (enemiesLeft <= 0)
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
}
