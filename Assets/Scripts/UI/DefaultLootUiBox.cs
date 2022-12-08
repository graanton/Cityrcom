using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefaultLootUiBox : LootUIBox
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected TextMeshProUGUI _nameLabel;
    [SerializeField] protected TextMeshProUGUI _typeLabel;

    public override LootBase loot => throw new System.NotImplementedException();

    public override void Init()
    {
        _icon.sprite = loot.lootData.icon;
        _nameLabel.text = loot.lootData.name;
        _typeLabel.text = loot.lootData.Type.ToString();
    }

    public override void SetLoot(LootBase loot)
    {
        throw new System.NotImplementedException();
    }
}
