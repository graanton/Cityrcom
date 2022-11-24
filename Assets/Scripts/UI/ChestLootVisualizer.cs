using System.Collections.Generic;
using UnityEngine;

public class ChestLootVisualizer : MonoBehaviour
{
    [SerializeField] private LootVisualizer _visualizer;
    [SerializeField] private Transform _visualizeParent;
    [SerializeField] private ChestHandler _chestHandler;

    readonly List<LootUIBox> _boxes = new();

    private void Awake()
    {
        _chestHandler.chestCloseEvent.AddListener(OnChestClosed);
        _chestHandler.chestOpenEvent.AddListener(OnChestOpened);
    }

    public void OnChestOpened(Chest chest)
    {
        foreach (var loot in chest.content)
        {
            LootUIBox box = _visualizer.CreateUISlot(_visualizeParent, loot);
            _boxes.Add(box);
        }
    }

    public void OnChestClosed(Chest chest)
    {
        foreach (LootUIBox box in _boxes)
        {
            Destroy(box.gameObject);
        }
        _boxes.Clear();
    }

}
