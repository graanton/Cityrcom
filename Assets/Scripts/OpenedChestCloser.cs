using System;
using UnityEngine;

public class OpenedChestCloser : MonoBehaviour
{
    [SerializeField] private ChestHandler _chestOpener;
    [SerializeField] private Interactor _chessFinder;

    private Chest _openedChest;

    private void Awake()
    {
        _chestOpener.chestOpenEvent.AddListener(OnChestOpen);
    }

    private void OnChestOpen(Chest chest)
    {
        _openedChest = chest;
    }

    private void Update()
    {
        if (_openedChest != null &&
            (_chessFinder.CulculateNearestColliderInteraction(out Collider currentCollider) && _openedChest.gameObject == currentCollider.gameObject) == false)
        {
            _chestOpener.Close();
            _openedChest = null;
        }
    }
}
