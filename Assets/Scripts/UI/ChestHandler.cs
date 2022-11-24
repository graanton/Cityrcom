using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestHandler : MonoBehaviour
{
    public ChestEvent chestOpenEvent;
    public ChestEvent chestCloseEvent;

    private Chest _openedChest;

    public void Open(Chest chest)
    {
        if (_openedChest != null)
        {
            throw new Exception("Close previous chest");
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
            throw new Exception("You can't close nothing");
        }
    }
}

[Serializable]
public class ChestEvent: UnityEvent<Chest>
{

}