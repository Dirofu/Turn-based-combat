using UnityEngine;

namespace Client
{
    public class CharacterInfo : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private Transform _activedSpellParent;

        public CharacterHealth CharacterHealth { get; private set; } 
        public HealthBar HealthBar => _healthBar;
        public Transform ActivedSpellParent => _activedSpellParent;

        public void Initialize(CharacterHealth characterHealth)
        {
            CharacterHealth = characterHealth;
            HealthBar.Initialize(characterHealth);
        }
    }
}
