using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class WeaponUISlot : DefaultLootUiBox
{
    [SerializeField] private TextMeshProUGUI _ammoLabel;
    [SerializeField] private TextMeshProUGUI _massLabel;
    private FireWeaponBase _weapon;

    public override LootBase loot => _weapon;

    public override void Init()
    {
        base.Init();
        _ammoLabel.text = _weapon.haveAmmo.ToString();
        _massLabel.text = ((LootFireWeaponData)_weapon.lootData).mass.ToString();
    }

    public override void SetLoot(LootBase weapon)
    {
        _weapon = (FireWeaponBase)weapon;
    }
}

[Serializable]
public class WeaponEvent: UnityEvent<WeaponBase> { }