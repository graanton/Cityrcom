using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class WeaponChange : MonoBehaviour, IRequester
{
    [SerializeField] private InventoryGetter _requestComliter;
    [SerializeField] private WeaponType _changeType;
    [SerializeField] private Transform _slotForWeaponParent;
    [SerializeField] private LootVisualizer _visalizer;

    public WeaponEvent changeEvent;

    private Button _button;
    private LootUIBox _weaponSlot;

    protected void Start()
    {
        _button = GetComponent<Button>();
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
        if (_weaponSlot != null)
        {
            Destroy(_weaponSlot.gameObject);
        }
        _weaponSlot = _visalizer.CreateUISlot(_slotForWeaponParent, box.loot);

        changeEvent?.Invoke((WeaponBase)_weaponSlot.loot);
    }
}
