using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GunShootUIInput : Button, IDragHandler
{
    [SerializeField] private GunShooter _gunShooter;
    [SerializeField] private ScreenInput _screenInput;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _screenInput.OnPointerDown(eventData);
        _gunShooter.StartShootingFromEquippedWeapon();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _screenInput.OnDrag(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _screenInput.OnPointerUp(eventData);
        _gunShooter.StopShootingWithEquippedWeapon();
    }
}
