using JetBrains.Annotations;
using UnityEngine;

public class HolsterSlot : MonoBehaviour
{
    public WeaponBase weapon { get; private set; }

    public void SetWeapon(WeaponBase weapon)
    {
        this.weapon = SpawnWeapon(weapon);
    }

    private WeaponBase SpawnWeapon(WeaponBase weaponForSpawn)
    {
        if (weapon != null)
        {
            Clear();
        }
        weapon = Instantiate(weaponForSpawn, transform);
        return weapon;
    }

    private void Clear()
    {
        Destroy(weapon.gameObject);
    }
}
