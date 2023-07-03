using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    [RequireComponent(typeof(SpellUser))]
    public class AISpellChooser : MonoBehaviour
    {
        [SerializeField] private List<Spell> _spells;

        private TurnBasedCombatSettuper _combatSettuper;
        private SpellUser _spellUser;

        private Dictionary<Spell, int> _spellCooldowns = new Dictionary<Spell, int>();

        private void OnEnable()
        {
            _combatSettuper = FindObjectOfType<TurnBasedCombatSettuper>();
            _combatSettuper.StepEnd += OnStepEnded;
        }

        private void OnDisable()
        {
            _combatSettuper.StepEnd -= OnStepEnded;
        }

        private void Awake()
        {
            _spellUser = GetComponent<SpellUser>();

            foreach (var spell in _spells)
                _spellCooldowns.Add(spell, 0);
        }

        public IEnumerator ChooseRandomSpell()
        {
            int spellID = 0;
            bool spellAvaible = false;
            var waitForEndOfFrame = new WaitForEndOfFrame();
            
            yield return new WaitForSeconds(1f);
            
            while (spellAvaible == false)
            {
                yield return waitForEndOfFrame;
                spellID = Random.Range(0, _spells.Count - 1);

                if (_spellCooldowns.TryGetValue(_spells[spellID], out int value))
                {
                    if (value <= 0)
                    {
                        spellAvaible = true;
                        _spellCooldowns[_spells[spellID]] = _spells[spellID].Cooldown;
                    }
                }
            }
            _spellUser.AIChooseSpell(_spells[spellID]);
        }

        private void OnStepEnded()
        {
            foreach (var spell in _spells)
            {
                _spellCooldowns.TryGetValue(spell, out int value);

                if (value > 0)
                    _spellCooldowns[spell] = value - 1;
            }
        }
    }
}