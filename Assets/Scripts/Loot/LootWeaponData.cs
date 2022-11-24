using UnityEngine;

[CreateAssetMenu(fileName = "weapon", menuName = "Loot/Weapon")]
public class LootWeaponData : LootData
{
    [SerializeField] private GunCartridgeType _cartridgeType;
    [SerializeField] private float _mass;

    public GunCartridgeType cartridgeType => _cartridgeType;
    public override LootType Type => LootType.weapon;
    public float mass => _mass;
}

public enum GunCartridgeType
{
    automatic,
    semiAutomatic
}
