using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChestLooter : MonoBehaviour, IRequester
{
    [SerializeField] private LootInventory _inventory;
    [SerializeField] private ChestHandler _handler;
    [SerializeField] private Button _lootActiveItemButton;
    [SerializeField] private ChestLootVisualizer _visualizer;
    [SerializeField] private LootGetter _lootChanger;

    private LootUIBox _selectedBox;

    private void Awake()
    {
        _handler.chestOpenEvent.AddListener(OnChestOpened);
        _lootActiveItemButton.onClick.AddListener(LootSelectedBox);
    }

    private void OnChestOpened(Chest chest)
    {
        _lootChanger.Request<LootUIBox>(this, _visualizer.visualizedLoots);
    }

    public void OnRequestComplited(LootUIBox box)
    {
        _selectedBox = box;
    }

    private void LootSelectedBox()
    {
        if (_selectedBox != null)
        {
            _inventory.AddLoot(_selectedBox.loot);
            Destroy(_selectedBox.gameObject);
        }
        
        _selectedBox = null;
    }
}
