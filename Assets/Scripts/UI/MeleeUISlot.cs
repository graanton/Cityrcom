using System.Collections;
using TMPro;
using UnityEngine;

public class MeleeUISlot : DefaultLootUiBox
{
    [SerializeField] private TextMeshProUGUI _massLabel;

    public override LootBase loot => _lootMelee;

    private MeleeBase _lootMelee;

    public override void Init()
    {
        base.Init();
        _massLabel.text = ((LootMeleeData)_lootMelee.lootData).mass.ToString();
    }

    public override void SetLoot(LootBase loot)
    {
        _lootMelee = (MeleeBase)loot;
    }
}
