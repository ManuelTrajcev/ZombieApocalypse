using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    const string PLAYER_STRING = "Player";
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
           OnPickUp(activeWeapon);
        }
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    protected abstract void OnPickUp(ActiveWeapon activeWeapon);
}
