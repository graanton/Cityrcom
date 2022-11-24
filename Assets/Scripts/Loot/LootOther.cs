using System.Collections;
using UnityEngine;

public class LootOther : LootBase
{
    [SerializeField] private int _count;
    [SerializeField] private LootOtherData _data;
    public override int count => _count;

    public override LootData lootData => _data;
}
