using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character Settings")]
    [SerializeField] private float _maxHealth;
    [SerializeField] private bool _isPlayer;

    [Space(10)]
    
    [Header("HealthBar Settings")]
    [SerializeField] private Transform _healthBarParent;
    [SerializeField] private HealthBar _healthBarPrefab;
    [SerializeField] private Transform _healthBarPosition;

    private float _health;

    public float CurrentHealth => _health;
    public float MaxHealth => _health;

    public event Action HealthChanged;

    private void Awake()
    {
        HealthBar health = Instantiate(_healthBarPrefab, _healthBarParent);

        _health = _maxHealth;
        health.Initialize(this, _healthBarPosition, _isPlayer);
    }
}
