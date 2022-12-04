using System;
using UnityEngine;

public class LootVisualizer : MonoBehaviour
{
    [SerializeField] private WeaponUISlot _weaponSlotPrefab;
    [SerializeField] private MeleeUISlot _meleeSlotPrefab;

    private Transform _createParent;

    public LootUIBox CreateUISlot(Transform parent, LootBase loot)
    {
        _createParent = parent;
        LootUIBox box;
        if (loot is FireWeaponBase)
        {
            box = DefaultInstantialte(_weaponSlotPrefab);
        }
        else if (loot is MeleeBase)
        {
            box = DefaultInstantialte(_meleeSlotPrefab);
        }
        else
        {
            throw new Exception("Unknow loot type");
        }
        box.SetLoot(loot);
        box.Init();
        return box;
    }

    private LootUIBox DefaultInstantialte(LootUIBox slotPrefab)
    {
        return Instantiate(slotPrefab, _createParent);
    }
}
