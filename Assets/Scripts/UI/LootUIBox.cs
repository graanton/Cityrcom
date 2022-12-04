using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class LootUIBox : MonoBehaviour
{
    [SerializeField] private bool _initInStart = true;

    public abstract LootBase loot { get; }

    private void Start()
    {
        if (_initInStart)
        {
            Init();
        }
    }

    public abstract void Init();

    public abstract void SetLoot(LootBase loot);
}
