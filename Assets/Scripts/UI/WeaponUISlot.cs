using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class WeaponUISlot : LootUIBox
{
    [SerializeField] private TextMeshProUGUI _ammoLabel;
    private FireWeaponBase _weapon;

    public WeaponEvent weaponSetEvent = new();

    public override LootBase loot => _weapon;

    public override void Init()
    {
        
    }

    public override void SetLoot(LootBase weapon)
    {
        _weapon = (FireWeaponBase)weapon;
        weaponSetEvent?.Invoke(_weapon);
    }
}

[Serializable]
public class WeaponEvent: UnityEvent<WeaponBase> { }