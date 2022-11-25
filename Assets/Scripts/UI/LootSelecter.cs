using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LootUIBox))]
public class LootSelecter : MonoBehaviour, IPointerDownHandler
{
    private IRequester _lootGetter;

    public void OnPointerDown(PointerEventData eventData)
    {
        _lootGetter.OnRequestComplited(GetComponent<LootUIBox>());
    }

    public void SetRequester(IRequester requester)
    {
        _lootGetter = requester;
    }
}
