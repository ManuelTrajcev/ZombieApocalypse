using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform turretHead;
    [SerializeField] private Transform playerTargetPoint; 
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnTime = 3f;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private GameObject projectilePrefab;
    void Update()
    {
        turretHead.LookAt(playerTargetPoint.position);
    }
    
    void Start()
    {
        StartCoroutine(SpawnProjectileRoutine());
        // player = FindFirstObjectByType<PlayerHealth>();
    }
    IEnumerator SpawnProjectileRoutine()
    {
        while (player)
        {
            Projectile projectile  = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.Init(20);
            projectile.transform.LookAt(playerTargetPoint.position);
            
            yield return new WaitForSeconds(spawnTime);
        }
    }
}