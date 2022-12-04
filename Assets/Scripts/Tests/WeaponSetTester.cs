using System.Collections;
using UnityEngine;

namespace Tests
{
    public class WeaponSetTester : MonoBehaviour
    {
        [SerializeField] private FireWeaponBase _weaponToSet;
        [SerializeField] private WeaponUISlot _gunSlot;
        [SerializeField] private WeaponSetter _weaponSetter;
        [SerializeField] private int _weaponIndex;

        private void Start()
        {
            _gunSlot.SetLoot(_weaponToSet);
            _weaponSetter.ChangeWeapon(_weaponIndex);
        }
    }
}