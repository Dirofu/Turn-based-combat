using System;
using TMPro;
using UnityEngine;

namespace Client
{
    public class CooldownTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private TurnBasedCombatSettuper _combatSettuper;
        private int _stepsCount;

        public event Action CooldownEnded;

        private void OnEnable()
        {
            if (_combatSettuper == null)
                _combatSettuper = FindObjectOfType<TurnBasedCombatSettuper>();

            _combatSettuper.StepEnd += OnStepEnd;
        }

        private void OnDisable()
        {
            _combatSettuper.StepEnd -= OnStepEnd;
        }

        public void Initialize(int cooldown)
        {
            _stepsCount = cooldown + 1;
            OnStepEnd();
        }

        private void OnStepEnd()
        {
            _stepsCount--;
            ShowStepsCount();

            if (_stepsCount <= 0)
                CooldownEnded?.Invoke();
        }

        private void ShowStepsCount() => _text.text = _stepsCount.ToString();
    }
}