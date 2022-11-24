using System.Collections;
using UnityEngine;

public abstract class LootBase : MonoBehaviour
{
    public abstract int count { get; }
    public abstract LootData lootData { get; }
}
