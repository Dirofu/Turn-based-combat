using UnityEngine;

namespace Client
{
    public class CharacterInfo : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private Transform _activedSpellParent;

        public HealthBar HealthBar => _healthBar;
        public Transform ActivedSpellParent => _activedSpellParent;
    }
}
