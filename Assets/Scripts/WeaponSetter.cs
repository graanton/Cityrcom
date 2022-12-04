using UnityEngine;
using System;
using System.Collections.Generic;

public class WeaponSetter : MonoBehaviour
{
    [SerializeField] private List<HolsterSlot> _weaponSlots;

    public WeaponEvent weaponChangedEvent;

    public void ChangeWeapon(int weaponIndex)
    {
        WeaponBase weaponToSet = _weaponSlots[weaponIndex].weapon;
        if (weaponToSet == null)
        {
            Debug.LogWarning("Holster slot void");
            return;
        }
        weaponChangedEvent?.Invoke(weaponToSet);
    }
}