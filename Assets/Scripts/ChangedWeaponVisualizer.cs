using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedWeaponVisualizer : MonoBehaviour
{
    [SerializeField] private List<HolsterSlot> _holsterSlots;

    public void HideUnactiveWeapon(WeaponBase exceptionWeapon)
    {
        foreach (HolsterSlot slot in _holsterSlots)
        {
            if (slot.weapon == null) { continue; }

            slot.weapon.gameObject.SetActive(slot.weapon == exceptionWeapon);
        }
    }
}