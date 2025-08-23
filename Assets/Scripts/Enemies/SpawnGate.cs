using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] private float spawnTime = 5f;
    [SerializeField] GameObject robotPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private PlayerHealth player;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        player = FindFirstObjectByType<PlayerHealth>();
    }
    IEnumerator SpawnEnemyRoutine()
    {
        while (player)
        {
            Instantiate(robotPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
