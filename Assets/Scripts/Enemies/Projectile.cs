using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    Rigidbody rb;
    [SerializeField] private int damageAmount = 2;
    [SerializeField] GameObject projectileHitVFX;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Init(int damage)
    {
        damageAmount = damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        
        playerHealth?.TakeDamage(damageAmount);
        Instantiate(projectileHitVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
