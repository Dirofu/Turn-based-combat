using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public class ActivedSpell : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _steps;

        private TurnBasedCombatSettuper _combatSettuper;

        private Spell _spell;
        private int _duration;

        private void OnEnable()
        {
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
            _duration--;

            if (_duration <= 0)
                Destroy(gameObject);

            VisualiseSteps();
        }

        private void VisualiseSteps() => _steps.text = _duration.ToString();
    }
}
