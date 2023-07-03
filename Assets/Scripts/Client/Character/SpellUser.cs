using System;
using UnityEngine;

namespace Client
{
    [RequireComponent(typeof(CharacterHealth))]
    public class SpellUser : MonoBehaviour
    {
        [SerializeField] private SpellStatus _activedSpellPrefab;

        [SerializeField] private SpellAnnouncer _announcer;
        [SerializeField] private CharacterHealth _enemy;

        private CharacterHealth _current;

        public event Action UseSpell;

        private void OnEnable()
        {
            if (_announcer != null)
                _announcer.SpellUsed += ChooseSpell;

            _current = GetComponent<CharacterHealth>();
        }

        private void OnDisable()
        {
            if (_announcer != null)
                _announcer.SpellUsed -= ChooseSpell;
        }

        public void AIChooseSpell(Spell spell) => ChooseSpell(spell);

        private void ChooseSpell(Spell spell)
        {
            switch (spell.Type)
            {
                case SpellType.Attack:
                    Attack(spell);
                    break;
                case SpellType.Barrier:
                    Barrier(spell);
                    break;
                case SpellType.Regeneration:
                    Regeneration(spell);
                    break;
                case SpellType.Fireball:
                    Fireball(spell);
                    break;
                case SpellType.Cleansing:
                    Cleansing(spell);
                    break;
            }
        }

        private void Attack(Spell spell)
        {
            _enemy.TakeDamage(spell.Value);
            CreateSpellAnnouncement(spell);
        }

        private void Barrier(Spell spell)
        {
            CreateSpellAnnouncement(spell);
            _current.EnableBarrier(spell);
        }

        private void Regeneration(Spell spell)
        {
            CreateSpellAnnouncement(spell);
        }

        private void Fireball(Spell spell)
        {
            _enemy.TakeDamage(spell.Value);
            CreateSpellAnnouncement(spell);
        }

        private void Cleansing(Spell spell)
        {
            CreateSpellAnnouncement(spell);
        }
            
        private void CreateSpellAnnouncement(Spell spell)
        {
            SpellStatus activedSpell;
            Transform targetPosition = spell.Type == SpellType.Fireball ? _enemy.ActivedSpellParent : _current.ActivedSpellParent;

            activedSpell = Instantiate(_activedSpellPrefab, targetPosition);
            activedSpell.Initialize(spell);
            UseSpell?.Invoke();
        }
    }
}