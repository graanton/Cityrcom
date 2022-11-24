using System;
using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private LootInventory _inventory;
    [SerializeField] private Transform _UIParent;
    [SerializeField] private LootVisualizer _visualizer;

    public List<LootUIBox> lootUIBoxes;

    private void Awake()
    {
        InitUI();
        _inventory.addEvent.AddListener(OnLootAdded);
    }

    private void InitUI()
    {
        foreach (LootBase loot in _inventory.storedLoots)
        {
            LootUIBox box = _visualizer.CreateUISlot(_UIParent, loot);
            lootUIBoxes.Add(box);
        }
    }

    private void OnLootAdded(LootBase addedLoot)
    {
        LootUIBox box = _visualizer.CreateUISlot(_UIParent, addedLoot);
        lootUIBoxes.Add(box);
    }
}