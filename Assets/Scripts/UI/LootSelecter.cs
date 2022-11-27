using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(LootUIBox))]
public class LootSelecter : Button
{
    private IRequester _lootTeker;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _lootTeker.OnRequestComplited(GetComponent<LootUIBox>());
    }

    public void SetRequester(IRequester requester)
    {
        _lootTeker = requester;
    }
}
