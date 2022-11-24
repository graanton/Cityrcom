using UnityEngine;

public abstract class LootData : ScriptableObject
{
    [SerializeField] protected Sprite _icon;

    public abstract LootType Type { get; }
    public Sprite icon => _icon;
}

public enum LootType
{
    other = 0,
    weapon = 1,
    knowledge = 2
}
