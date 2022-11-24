using System;
using UnityEngine;

public class LootVisualizer : MonoBehaviour
{
    [SerializeField] private WeaponUISlot _weaponSlotPrefab;

    public LootUIBox CreateUISlot(Transform parent, LootBase loot)
    {
        LootUIBox box;
        if (loot is WeaponBase)
        {
            box = Instantiate(_weaponSlotPrefab, parent);
        }
        else
        {
            throw new Exception("Unknow loot type");
        }
        box.SetLoot(loot);
        box.Init();
        return box;
    }
}
