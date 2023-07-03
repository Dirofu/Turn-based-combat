using System;
using UnityEngine;
using Server;

namespace Client
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;
        
        [SerializeField] private bool _isPlayer;

        private float _health;
        private float _maxHealth;

        private WebCharacterHealth _webHealth;

        public float CurrentHealth => _health;
        public float MaxHealth => _maxHealth;

        public event Action HealthChanged;

        public void Awake()
        {
            _webHealth = new WebCharacterHealth();
            _webHealth.GetHealth(out _health, out _maxHealth);

            _healthBar.Initialize(this);
        }

        public void TakeDamage(float damage)
        {
            bool result = _webHealth.TryTakeDamage(damage);
            _webHealth.GetHealth(out _health, out _maxHealth);

            if (result == true)
                return;

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
}