using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(LootUIBox))]
public class WeaponChange : MonoBehaviour, IRequester
{
    [SerializeField] private LootGetter _requestComliter;

    private LootUIBox _box;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();   
        _box = GetComponent<LootUIBox>();
        _button.onClick.AddListener(Request);
    }

    private void Request()
    {
        _requestComliter.comliteEvent.AddListener(OnRequestComplited);
        _requestComliter.RequestFromInventory<WeaponBase>(this);
    }

    public void OnRequestComplited(LootUIBox box)
    {
        _box.SetLoot(box.loot);
        _box.Init();
    }
}
