using System.Collections.Generic;

namespace Server
{
    public class WebSpellUser
    {
        private Dictionary<Spell, int> _spellCooldowns = new Dictionary<Spell, int>();
    }
}
