using AYellowpaper.SerializedCollections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public class TurnBasedCombatSettuper : MonoBehaviour
    {
        [SerializeField] private SpellUser _player;
        [SerializeField] private SpellUser _enemy;

        [SerializeField] private SpellAnnouncer _spells;
        [SerializeField] private Button[] _buttons;

        private AISpellChooser _aISpellChooser;

        public event Action StepEnd;

        private void OnEnable()
        {
            _player.UseSpell += StopPlayerMove;
            _enemy.UseSpell += StopEnemyMove;
        }

        private void OnDisable()
        {
            _player.UseSpell -= StopPlayerMove;
            _enemy.UseSpell -= StopEnemyMove;
        }

        private void Awake()
        {
            ChangeStep();
        }

        public void StopPlayerMove()
        {
            foreach (var button in _buttons)
                button.interactable = false;

            StartEnemyMove();
        }

        public void StopEnemyMove()
        {
            ChangeStep();
        }

        private void ChangeStep()
        {
            StepEnd?.Invoke();
            StartPlayerMove();
        }

        private void StartPlayerMove()
        {
            foreach (var button in _buttons)
            {
                if (button.GetComponentInChildren<CooldownTimer>() == null)
                    button.interactable = true;
            }
        }

        private void StartEnemyMove()
        {
            if (_aISpellChooser == null)
                _aISpellChooser = _enemy.GetComponent<AISpellChooser>();

            StartCoroutine(_aISpellChooser.ChooseRandomSpell());
        }
    }
}