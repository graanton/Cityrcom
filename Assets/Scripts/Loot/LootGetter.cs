using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class LootGetter: MonoBehaviour
{
    [SerializeField] private InventoryUI _inventory;
    [SerializeField] private Transform _choicePanel;

    public UnityEvent requestGetEvent = new();
    public LootEvent  comliteEvent = new();

    private bool _isRequesting;

    public bool Request<T>()
    {
        if (_isRequesting)
        {
            return false;
        }
        Clear();
        requestGetEvent?.Invoke();
        foreach (LootUIBox item in _inventory.lootUIBoxes)
        {
            if (item.loot is T)
            {
                LootUIBox box = Instantiate(item, _choicePanel);
                box.SetLoot(item.loot);
                box.Init();
                LootSelecter selecter = box.gameObject.AddComponent<LootSelecter>();
                selecter.SetRequester(this);
            }
        }
        _isRequesting = true;
        return _isRequesting;
    }

    public void CompliteRequest(LootBase loot)
    {
        comliteEvent?.Invoke(loot);
        _isRequesting = false;
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