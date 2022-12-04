using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee", menuName = "Loot/Melee")]
public class LootMeleeData : LootWeaponData
{
    public override WeaponType WeaponType => WeaponType.melee;
}
