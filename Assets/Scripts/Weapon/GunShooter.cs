using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GunShooter : MonoBehaviour
{
    public WeaponSetEvent weaponSettedEvent;

    private WeaponBase _equippedWeapon;

    public void SetWeapon(WeaponBase weapon)
    {
        _equippedWeapon = weapon;
        weaponSettedEvent?.Invoke(weapon);
    }

    public void StartShootingFromEquippedWeapon()
    {
        _equippedWeapon.StartShooting();
    }

    public void StopShootingWithEquippedWeapon()
    {
        _equippedWeapon.StopShooting();
    }

}

public class WeaponSetEvent: UnityEvent<WeaponBase>
{

}