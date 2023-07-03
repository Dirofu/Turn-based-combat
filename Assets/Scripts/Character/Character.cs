using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character Settings")]
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _maxHealth;
    [SerializeField] private bool _isPlayer;

    private float _health;

    public float CurrentHealth => _health;
    public float MaxHealth => _health;

    public event Action HealthChanged;

    private void Awake()
    {
        _health = _maxHealth;
        _healthBar.Initialize(this, _isPlayer);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _health -= damage;

        if (_health <= 0)
            Die();

        HealthChanged?.Invoke();
    }

    private void Die()
    {
        _health = 0;
        Debug.Log("Die");
    }
}
