using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class LootInventory : MonoBehaviour
{
    public List<LootBase> storedLoots;

    public LootEvent addEvent = new();

    public void AddLoot(LootBase loot)
    {
        storedLoots.Add(loot);
        addEvent.Invoke(loot);
    }
}