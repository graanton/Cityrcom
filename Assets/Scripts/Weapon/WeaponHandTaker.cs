using System.Collections;
using UnityEngine;

public class WeaponHandTaker : MonoBehaviour
{
    [SerializeField] private GunShooter _gunShooter;
    [SerializeField] private Transform _leftHand, _rightHand;

    private void Awake()
    {
        _gunShooter.weaponSettedEvent.AddListener(OnWeaponSetted);
    }

    private void OnWeaponSetted(WeaponBase weapon)
    {
        _leftHand.position = weapon.leftHandPoint.position;
        _rightHand.position = weapon.rightHandPoint.position;
    }
}
