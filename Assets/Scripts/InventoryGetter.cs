using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InventoryGetter : MonoBehaviour, IRequester
{
    [SerializeField] private LootInventory _inventory;
    [SerializeField] private LootGetter _requestCompliter;
    [SerializeField] private Transform _choicePanel;
    [SerializeField] private LootVisualizer _slotVisualizer;

    public UnityEvent requestGetEvent;
    public UnityEvent requestCompliteEvent;

    private IRequester _currentRequester;

    public void RequestFromInventory<T>(IRequester requester)
    {
        if (_currentRequester != null)
        {
            Debug.LogError("Compite previous request");
            return;
        }

        Clear();

        _currentRequester = requester;

        foreach (LootBase item in _inventory.storedLoots)
        {
            if (item is T)
            {
                LootUIBox box = _slotVisualizer.CreateUISlot(_choicePanel, item);
                LootSelecter selecter = box.gameObject.AddComponent<LootSelecter>();
                selecter.SetRequester(this);
            }
        }

        requestGetEvent?.Invoke();
    }

    private void Clear()
    {
        foreach (Transform box in _choicePanel)
        {
            Destroy(box.gameObject);
        }
    }

    public void OnRequestComplited(LootUIBox box)
    {
        _currentRequester.OnRequestComplited(box);
        _currentRequester = null;
        requestCompliteEvent?.Invoke();
    }
}