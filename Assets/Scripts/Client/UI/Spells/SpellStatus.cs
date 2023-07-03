using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public class SpellStatus : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _steps;

        private TurnBasedCombatSettuper _combatSettuper;
        private CharacterInfo _info;
        private Spell _spell;
        private int _duration;

        public Spell Spell => _spell;

        private void OnEnable()
        {
            _info = GetComponentInParent<CharacterInfo>();
            _combatSettuper = FindObjectOfType<TurnBasedCombatSettuper>();
            _combatSettuper.StepEnd += OnChangeStep;
        }

        private void OnDisable()
        {
            _combatSettuper.StepEnd -= OnChangeStep;
        }

        public void Initialize(Spell spell)
        {
            _spell = spell;
            _image.sprite = _spell.SpellVisual;
            _duration = _spell.Duration + 1;
            OnChangeStep();
            VisualiseSteps();
        }

        public void OnChangeStep()
        {
            AffectSpellOnStep();
            _duration--;

            if (_duration <= 0)
            {
                _info.CharacterHealth.DisableBarrier();
                Destroy(gameObject);
            }

            VisualiseSteps();
        }

        private void AffectSpellOnStep()
        {
            switch (_spell.Type)
            {
                case SpellType.Regeneration:
                    _info.CharacterHealth.AddHealth(_spell.PowerOnStep);
                    break;

                case SpellType.Fireball:
                    if (_duration != _spell.Duration)
                        _info.CharacterHealth.TakeDamage(_spell.PowerOnStep);
                    break;

                case SpellType.Cleansing:

                    var spells = _info.GetComponentsInChildren<SpellStatus>();

                    foreach (var spellStatus in spells)
                    {
                        if (spellStatus.Spell.Type == SpellType.Fireball)
                        {
                            Destroy(spellStatus.gameObject);
                            Destroy(gameObject);
                        }
                    }
                    break;
            }
        }

        private void VisualiseSteps() => _steps.text = _duration.ToString();
    }
}
