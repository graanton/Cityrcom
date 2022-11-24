using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LootUIBox))]
public class LootSelecter : MonoBehaviour, IPointerDownHandler
{
    private LootGetter _lootGetter;

    public void OnPointerDown(PointerEventData eventData)
    {
        _lootGetter.CompliteRequest(GetComponent<LootUIBox>().loot);
    }

    public void SetRequester(LootGetter requester)
    {
        _lootGetter = requester;
    }
}
