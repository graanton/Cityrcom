using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChestLooter : MonoBehaviour
{
    [SerializeField] private LootInventory _inventory;
    [SerializeField] private ChestHandler _handler;
    [SerializeField] private Button _lootActiveItemButton;
    [SerializeField] private ChestLootVisualizer _visualizer;

    private Chest _selectedChest;

    private void Awake()
    {
        _handler.chestOpenEvent.AddListener(OnChestOpened);
    }

    private void OnChestOpened(Chest chest)
    {
        _selectedChest = chest;
        foreach (var box in _visualizer.visualizedLoots)
        {
                 
        }
    }
}
