using UnityEngine;
using System;

public class WeaponSetter : MonoBehaviour
{
    [SerializeField] private GunShooter _gunShooter;
    [SerializeField] private HolsterSlot[] _weaponSlots;

    public void ChangeWeapon(int weaponIndex)
    {
        WeaponBase weaponToSet = _weaponSlots[weaponIndex].weapon;
        if (weaponToSet == null)
        {
            throw new NullReferenceException();
        }
        _gunShooter.SetWeapon(weaponToSet);
    }
}