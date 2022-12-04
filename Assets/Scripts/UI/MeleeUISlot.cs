using System.Collections;
using UnityEngine;

public class MeleeUISlot : LootUIBox
{
    public override LootBase loot => _lootMelee;

    private MeleeBase _lootMelee;

    public override void Init()
    {
        
    }

    public override void SetLoot(LootBase loot)
    {
        _lootMelee = (MeleeBase)loot;
    }
}
