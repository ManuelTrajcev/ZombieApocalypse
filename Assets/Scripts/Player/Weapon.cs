using Cinemachine;
using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    private Camera _camera;
    [SerializeField] LayerMask interactionLayers;
    CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        _camera = Camera.main;
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shoot(WeaponSO weaponSo)
    {
        RaycastHit hit;
        particleSystem.Play();
        impulseSource.GenerateImpulse();
        
        if (Physics.Raycast(Camera.main.transform.position, _camera.transform.forward, out hit, Mathf.Infinity,
                interactionLayers, QueryTriggerInteraction.Ignore))
        {
            Instantiate(weaponSo.HitVFXPrefab, hit.point, Quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            
            enemyHealth?.TakeDamage(weaponSo.Damage);
        }
    }
}