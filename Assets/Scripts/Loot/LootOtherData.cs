using UnityEngine;

[CreateAssetMenu(fileName = "other", menuName = "Loot/Other")]
public class LootOtherData : LootData
{
    [SerializeField] private float _mass;
    public float mass => _mass;

    public override LootType Type => LootType.other;
}
