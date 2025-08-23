using UnityEngine;

public class WeaponPickUp : PickUp
{
   [SerializeField] private WeaponSO weaponSo;
   
   protected override void OnPickUp(ActiveWeapon activeWeapon)
   {
      activeWeapon.SwitchWeapon(weaponSo);
      Destroy(gameObject);   }
}
