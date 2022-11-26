using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class LootGetter: MonoBehaviour
{
    public List<LootSelecter> Request<T>(IRequester requester, List<LootUIBox> boxes)
    {
        List<LootSelecter> selecters = new();
        foreach (LootUIBox box in boxes)
        {
            LootSelecter selecter = box.gameObject.AddComponent<LootSelecter>();
            selecter.SetRequester(requester);
            selecters.Add(selecter);
        }
        return selecters;
    }
}

[Serializable]
public class LootEvent : UnityEvent<LootBase>
{
    
}

public interface IRequester
{
    void OnRequestComplited(LootUIBox box);
}