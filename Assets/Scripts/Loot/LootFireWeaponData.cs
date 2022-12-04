using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Loot/Fire")]
public class LootFireWeaponData : LootWeaponData
{
    [SerializeField] private FireWeaponCartridgeType _cartridgeType;

    public FireWeaponCartridgeType cartridgeType => _cartridgeType;
    public override WeaponType WeaponType => WeaponType.fire;
}

public enum FireWeaponCartridgeType
{
    automatic,
    semiAutomatic
}
