using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefaultEnemyAI : MonoBehaviour, IEntity
{
    [SerializeField] private int _maxHealth;
    public HitEvent hitEvent = new();
    private int _health;
    public int health => _health;

    private void Start()
    {
        _health = _maxHealth;
        hitEvent.AddListener(OnDamageTaken);
    }

    public void TakeDamage(int damage)
    {
        hitEvent?.Invoke(damage);
    }

    private void OnDamageTaken(int damage)
    {
        _health -= damage;
    }
}

public class HitEvent: UnityEvent<int> { }