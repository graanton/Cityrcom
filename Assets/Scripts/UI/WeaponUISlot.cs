using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class WeaponUISlot : LootUIBox
{
    [SerializeField] private TextMeshProUGUI _ammoLabel;
    private WeaponBase _weapon;

    public UnityEvent weaponSetEvent { get; private set; } = new();

    public override LootBase loot => _weapon;

    public override void Init()
    {
        base.Init();
    }

    public override void SetLoot(LootBase weapon)
    {
        _weapon = (WeaponBase)weapon;
        weaponSetEvent?.Invoke();
    }
}
