using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestHandler : MonoBehaviour
{
    public ChestEvent chestOpenEvent = new();
    public ChestEvent chestCloseEvent = new();

    private Chest _openedChest;

    public void Open(Chest chest)
    {
        if (_openedChest != null)
        {
            Debug.LogError("Close previous chest");
            return;
        }
        _openedChest = chest;
        chestOpenEvent?.Invoke(_openedChest);
    }

    public void Close()
    {
        if (_openedChest != null)
        {
            chestCloseEvent?.Invoke(_openedChest);
            _openedChest = null;
        }
        else
        {
            Debug.LogError("You can't close nothing");
        }
    }
}

[Serializable]
public class ChestEvent: UnityEvent<Chest>
{

}