using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChestLooter : MonoBehaviour, IRequester
{
    [SerializeField] private LootInventory _inventory;
    [SerializeField] private Button _lootActiveItemButton;
    [SerializeField] private ChestHandler _chestHandler;
    [SerializeField] private ChestLootVisualizer _visualizer;
    [SerializeField] private LootGetter _lootChanger;

    private Chest _openedChest;
    private LootUIBox _selectedBox;
    private List<LootUIBox> _visualizedLoots;

    private void Awake()
    {
        _lootActiveItemButton.onClick.AddListener(LootSelectedBox);
        _visualizer.chestVisualizedEvent.AddListener(OnLootVisualized);
        _chestHandler.chestOpenEvent.AddListener(OnChestOpened);
        _chestHandler.chestCloseEvent.AddListener(OnChestClosed);
    }

    private void OnChestOpened(Chest chest)
    {
        _openedChest = chest;
    }

    private void OnChestClosed(Chest chest)
    {
        _openedChest = null;
    }

    private void OnLootVisualized(List<LootUIBox> visualizedLoots)
    {
        _visualizedLoots = visualizedLoots;
        _lootChanger.Request<LootUIBox>(this, _visualizedLoots);
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
            _visualizedLoots.Remove(_selectedBox);

            Destroy(_selectedBox.gameObject);
        }
        
        _selectedBox = null;
    }
}
