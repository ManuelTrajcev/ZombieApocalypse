using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;
    const string PLAYER_STRING = "Player";
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
    }

    private void Update()
    {
        if (!player)
        {
            return;
        }
        agent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_STRING))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SelfDestruct();
        }
    }
}