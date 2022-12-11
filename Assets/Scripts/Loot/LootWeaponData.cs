using Unity.VisualScripting;
using UnityEngine;

public abstract class LootWeaponData : LootData
{
    [SerializeField] private float _mass;
    [SerializeField] private int _damage;

    public override LootType Type => LootType.weapon;
    public abstract WeaponType WeaponType { get; }

    public int damage => _damage;
    public float mass => _mass;
}

public enum WeaponType
{
    fire,
    melee
}

public interface IEntity
{
    int health { get; }
    void TakeDamage(int damage);  
}