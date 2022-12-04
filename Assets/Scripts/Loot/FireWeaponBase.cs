using UnityEngine;

public abstract class FireWeaponBase: WeaponBase
{
    [SerializeField] protected LootFireWeaponData _weaponData;

    public override LootData lootData => _weaponData;
    public abstract int haveAmmo { get; }
}
