using System.Collections;
using UnityEngine;

public class InventoryGetter : MonoBehaviour
{
    [SerializeField] private LootInventory _inventory;
    [SerializeField] private LootGetter _requestCompliter;
    [SerializeField] private Transform _choicePanel;
    [SerializeField] private LootVisualizer _slotVisualizer;

    public void RequestFromInventory<T>(IRequester requester)
    {
        Clear();

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

    private void Clear()
    {
        foreach (Transform box in _choicePanel)
        {
            Destroy(box.gameObject);
        }
    }
}