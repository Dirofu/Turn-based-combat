using System;
using UnityEngine;
using Server;

namespace Client
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private CharacterInfo _info;

        private float _health;
        private float _maxHealth;

        private WebCharacterHealth _webHealth;

        public Transform ActivedSpellParent => _info.ActivedSpellParent;
        public float CurrentHealth => _health;
        public float MaxHealth => _maxHealth;

        public event Action HealthChanged;

        public void Awake()
        {
            _webHealth = new WebCharacterHealth();
            _webHealth.GetHealth(out _health, out _maxHealth);

            _info.HealthBar.Initialize(this);
        }

        public void TakeDamage(float damage)
        {
            bool result = _webHealth.TryTakeDamage(damage);
            _webHealth.GetHealth(out _health, out _maxHealth);
            HealthChanged?.Invoke();

            if (result == true)
                return;

            if (_health <= 0)
                Die();
        }

        private void Die()
        {
            Debug.Log("Die");
        }
    }
}