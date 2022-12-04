using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GunShooter : MonoBehaviour
{
    public WeaponBase _equippedWeapon { get; private set; }

    public void SetWeapon(WeaponBase weapon)
    {
        _equippedWeapon = weapon;
    }

    public void StartShootingFromEquippedWeapon()
    {
        if (_equippedWeapon != null)
        {
            _equippedWeapon.StartAttacking();
        }
    }

    public void StopShootingWithEquippedWeapon()
    {
        if (_equippedWeapon != null)
        {
            _equippedWeapon.StopAttacking();
        }
    }
}