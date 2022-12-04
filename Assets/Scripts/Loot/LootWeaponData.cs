using UnityEngine;

public abstract class LootWeaponData : LootData
{
    [SerializeField] private float _mass;

    public override LootType Type => LootType.weapon;
    public abstract WeaponType WeaponType { get; }

    public float mass => _mass;
}

public enum WeaponType
{
    fire,
    melee
}