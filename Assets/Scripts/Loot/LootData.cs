using UnityEngine;

public abstract class LootData : ScriptableObject
{
    [SerializeField] private Sprite _icon;

    public abstract LootType Type { get; }
    public Sprite icon => _icon;
}

public enum LootType
{
    other,
    weapon,
    knowledge
}
