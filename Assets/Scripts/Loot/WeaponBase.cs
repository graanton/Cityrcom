using System.Collections;
using UnityEngine;

public abstract class WeaponBase : LootBase
{
    public override int count => 1;

    public abstract void StartAttacking();
    public abstract void StopAttacking();
}
