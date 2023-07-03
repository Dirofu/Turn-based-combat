using UnityEngine;

namespace Client
{
    public class SpellButton : MonoBehaviour
    {
        [SerializeField] private Spell _spell;

        private SpellAnnouncer _announcer;

        private void Awake()
        {
            _announcer = GetComponentInParent<SpellAnnouncer>();
        }

        public void UseSpell()
        {
            _announcer.UseSpell(_spell);
        }
    }
}