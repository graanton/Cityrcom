using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(LootUIBox))]
public class WeaponChange : MonoBehaviour
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
        _requestComliter.Request<WeaponBase>();
    }

    private void OnRequestComplited(LootBase weapon)
    {
        _box.SetLoot(weapon);
        _box.Init();
    }
}
