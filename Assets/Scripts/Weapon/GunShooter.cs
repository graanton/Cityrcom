using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GunShooter : MonoBehaviour
{
    public WeaponSetEvent weaponSettedEvent = new();

    public WeaponBase _equippedWeapon { get; private set; }

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