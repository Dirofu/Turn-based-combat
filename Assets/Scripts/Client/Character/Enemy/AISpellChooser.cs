using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    [RequireComponent(typeof(SpellUser))]
    public class AISpellChooser : MonoBehaviour
    {
        [SerializeField] private List<Spell> _spells;

        private SpellUser _spellUser;

        private void Awake()
        {
            _spellUser = GetComponent<SpellUser>();
        }

        public void ChooseRandomSpell()
        {
            int spellID = Random.Range(0, _spells.Count - 1);
            _spellUser.AIChooseSpell(_spells[spellID]);
        }
    }
}