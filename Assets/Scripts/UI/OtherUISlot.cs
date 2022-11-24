using System.Collections;
using UnityEngine;


public class OtherUISlot : LootUIBox
{
    private LootOther _lootOther;
    public override LootBase loot => _lootOther;

    public override void SetLoot(LootBase loot)
    {
        throw new System.NotImplementedException();
    }
}
