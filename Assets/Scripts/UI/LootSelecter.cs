using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(LootUIBox))]
public class LootSelecter : Button
{
    private IRequester _lootGetter;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _lootGetter.OnRequestComplited(GetComponent<LootUIBox>());
    }

    public void SetRequester(IRequester requester)
    {
        _lootGetter = requester;
    }
}
