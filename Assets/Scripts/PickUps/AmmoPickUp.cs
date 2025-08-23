using UnityEngine;

public class AmmoPickUp : PickUp
{
    [SerializeField] private int ammoAmount = 100;

    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmo(ammoAmount);
        Destroy(gameObject);
    }
}