using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] int startingHealth = 10;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] private Transform weaponCamera;
    [SerializeField] private Image[] shieldBars;
    [SerializeField] GameObject gameOverUI;
    int currentHealth;
    private int gameOverVirtualCameraPriority = 20;

    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldUI();
    }
 
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        AdjustShieldUI();
        if (currentHealth <= 0)
        {
            GameOver();
        } 
    }

    private void GameOver()
    {
        weaponCamera = null;
        deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
        gameOverUI.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(gameObject);
    }

    private void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}
