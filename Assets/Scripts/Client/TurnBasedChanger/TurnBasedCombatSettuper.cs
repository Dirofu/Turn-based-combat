using System;
using UnityEngine;

namespace Client
{
    public class TurnBasedCombatSettuper : MonoBehaviour
    {
        [SerializeField] private SpellUser _player;
        [SerializeField] private SpellUser _enemy;

        [SerializeField] private SpellAnnouncer _spells;

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
            _spells.gameObject.SetActive(true);
        }

        private void StartEnemyMove()
        {
            _spells.gameObject.SetActive(false);

            if (_aISpellChooser == null)
                _aISpellChooser = _enemy.GetComponent<AISpellChooser>();

            StartCoroutine(_aISpellChooser.ChooseRandomSpell());
        }
    }
}