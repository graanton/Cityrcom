using System.Collections;
using UnityEngine;

public abstract class MeleeBase : WeaponBase
{
    [SerializeField] protected LootMeleeData _weaponData;

    public override LootData lootData => _weaponData;
}