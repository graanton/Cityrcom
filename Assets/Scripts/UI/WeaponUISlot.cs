using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class WeaponUISlot : LootUIBox
{
    [SerializeField] private TextMeshProUGUI _ammoLabel;
    private FireWeaponBase _weapon;

    public override LootBase loot => _weapon;

    public override void Init()
    {
        _ammoLabel.text = _weapon.haveAmmo.ToString();
    }

    public override void SetLoot(LootBase weapon)
    {
        _weapon = (FireWeaponBase)weapon;
    }
}

[Serializable]
public class WeaponEvent: UnityEvent<WeaponBase> { }