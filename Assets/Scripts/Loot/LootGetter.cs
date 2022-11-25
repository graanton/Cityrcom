using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class LootGetter: MonoBehaviour
{
    [SerializeField] private LootInventory _inventory;
    [SerializeField] private Transform _choicePanel;
    [SerializeField] private LootVisualizer _slotVisualizer;

    public UnityEvent requestGetEvent = new();
    public SelectEvent comliteEvent = new();

    public void RequestFromInventory<T>(IRequester requester)
    {
        Clear();
        requestGetEvent?.Invoke();
        foreach (LootBase item in _inventory.storedLoots)
        {
            if (item is T)
            {
                LootUIBox box = _slotVisualizer.CreateUISlot(_choicePanel, item);
                LootSelecter selecter = box.gameObject.AddComponent<LootSelecter>();
                selecter.SetRequester(requester);
            }
        }
    }

    public void CompliteRequest(LootUIBox loot)
    {
        comliteEvent?.Invoke(loot);
    }

    private void Clear()
    {
        foreach (Transform box in _choicePanel)
        {
            Destroy(box.gameObject);
        }
    }
}

[Serializable]
public class LootEvent : UnityEvent<LootBase>
{
    
}

[Serializable]
public class SelectEvent : UnityEvent<LootUIBox>
{
    
}

public interface IRequester
{
    void OnRequestComplited(LootUIBox box);
}