using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class WeaponChange : MonoBehaviour, IRequester
{
    [SerializeField] private InventoryGetter _requestComliter;
    [SerializeField] private WeaponType _changeType;

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
        switch (_changeType)
        {
            case WeaponType.fire:
                RequsetsWeaponType<FireWeaponBase>();
                break;
            case WeaponType.melee:
                RequsetsWeaponType<MeleeBase>();
                break;
        }
    }

    private void RequsetsWeaponType<T>()
    {
        _requestComliter.RequestFromInventory<T>(this);
    }

    public void OnRequestComplited(LootUIBox box)
    {
        _box.SetLoot(box.loot);
        _box.Init();
    }
}
