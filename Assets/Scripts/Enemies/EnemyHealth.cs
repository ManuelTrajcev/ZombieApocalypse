using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;
    [SerializeField] private GameObject robotExplosion;
    GameManager gameManager;
    int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        gameManager.AdjustEnemiesLeft(-1);
        Instantiate(robotExplosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}