using System;
using UnityEngine;

namespace Client
{
    public class SpellAnnouncer : MonoBehaviour
    {
        public event Action<Spell> SpellUsed;

        public void UseSpell(Spell spell) => SpellUsed?.Invoke(spell);
    }
}