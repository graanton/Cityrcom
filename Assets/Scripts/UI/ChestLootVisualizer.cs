using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestLootVisualizer : MonoBehaviour
{
    [SerializeField] private LootVisualizer _visualizer;
    [SerializeField] private Transform _visualizeParent;
    [SerializeField] private ChestHandler _chestHandler;

    private List<LootUIBox> visualizedLoots = new();

    public VisualizeEvent chestVisualizedEvent;

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
            visualizedLoots.Add(box);
        }
        chestVisualizedEvent?.Invoke(visualizedLoots);
    }

    public void OnChestClosed(Chest chest)
    {
        foreach (LootUIBox box in visualizedLoots)
        {
            Destroy(box.gameObject);
        }
        visualizedLoots.Clear();
    }
}

[Serializable] 
public class VisualizeEvent: UnityEvent<List<LootUIBox>> { }
