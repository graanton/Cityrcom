using UnityEngine;

public abstract class  WeaponBase: LootBase
{
    [SerializeField] protected LootWeaponData _weaponData;

    public Transform leftHandPoint, rightHandPoint, localPoint;

    public override LootData lootData => _weaponData;
    public abstract int haveAmmo { get; }

    public abstract void StartShooting();
    public abstract void StopShooting();
}
