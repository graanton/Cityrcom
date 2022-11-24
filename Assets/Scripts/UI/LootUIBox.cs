using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class LootUIBox : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _lootNameLabel;
    [SerializeField] protected Image _lootIconField;
    [SerializeField] protected TextMeshProUGUI _lootTypeLabel;

    public abstract LootBase loot { get; }

    public virtual void Init()
    {
        if (loot == null)
        {
            _lootNameLabel.text = string.Empty;
            _lootTypeLabel.text = string.Empty;
        }
        else
        {
            _lootIconField.sprite = loot.lootData.icon;
            _lootNameLabel.text = loot.lootData.name;
            _lootTypeLabel.text = loot.lootData.Type.ToString();
        }
    }

    public abstract void SetLoot(LootBase loot);
}
