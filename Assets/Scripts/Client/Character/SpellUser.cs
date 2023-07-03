using System;
using UnityEngine;

namespace Client
{
    [RequireComponent(typeof(CharacterHealth))]
    public class SpellUser : MonoBehaviour
    {
        [SerializeField] private Transform _activedSpellParent;
        [SerializeField] private ActivedSpell _activedSpellPrefab;

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
            CreateSpellAnnouncement(spell);
        }

        private void Barrier(Spell spell)
        {
            CreateSpellAnnouncement(spell);
        }

        private void Regeneration(Spell spell)
        {
            CreateSpellAnnouncement(spell);
        }

        private void Fireball(Spell spell)
        {
            CreateSpellAnnouncement(spell);
        }

        private void Cleansing(Spell spell)
        {
            CreateSpellAnnouncement(spell);
        }

        private void CreateSpellAnnouncement(Spell spell)
        {
            Debug.Log($"{spell.Type} {gameObject.name}");
            var activedSpell = Instantiate(_activedSpellPrefab, _activedSpellParent);
            activedSpell.Initialize(spell);
            UseSpell?.Invoke();
        }
    }
}