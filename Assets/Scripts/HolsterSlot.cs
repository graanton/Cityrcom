using JetBrains.Annotations;
using UnityEngine;

public class HolsterSlot : MonoBehaviour
{
    [SerializeField] private WeaponUISlot _weaponUISlot;

    public WeaponBase weapon { get; private set; }

    private void Awake()
    {
        _weaponUISlot.weaponSetEvent.AddListener(OnWeaponSetted);
    }

    private void OnWeaponSetted()
    {
        if (weapon != null)
        {
            Clear();
        }
        SpawnWeapon((WeaponBase)_weaponUISlot.loot);
    }

    public WeaponBase SpawnWeapon(WeaponBase weaponForSpawn)
    {
        weapon = Instantiate(weaponForSpawn, transform);
        return weapon;
    }

    private void Clear()
    {
        Destroy(transform.GetChild(0).gameObject);
    }
}
