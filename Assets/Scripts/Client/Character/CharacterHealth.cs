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

            _info.Initialize(this);
        }

        public void TakeDamage(float damage)
        {
            _webHealth.TakeDamage(damage);
            _webHealth.GetHealth(out _health, out _maxHealth);
            HealthChanged?.Invoke();

            if (_health <= 0)
                Die();
        }

        public void AddHealth(float health)
        {
            _webHealth.AddHealth(health);
            _webHealth.GetHealth(out _health, out _maxHealth);
            HealthChanged?.Invoke();
        }

        public void EnableBarrier(Spell spell) => _webHealth.EnableBarrier(spell.Value);
        public void DisableBarrier() => _webHealth.DisableBarrier();
        private void Die() => FindObjectOfType<LevelLoader>().RestartLevel();
    }
}