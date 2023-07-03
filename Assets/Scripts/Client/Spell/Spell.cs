using UnityEngine;

namespace Client
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Create New Spell", order = 51)]
    public class Spell : ScriptableObject
    {
        [field: SerializeField] public Sprite SpellVisual { get; private set; }
        [field: SerializeField] public int Duration { get; private set; }
        [field: SerializeField] public int Cooldown { get; private set; }
        [field: SerializeField] public int PowerOnStep { get; private set; }
        [field: SerializeField] public int Value { get; private set; }
        [field: SerializeField] public SpellType Type { get; private set; }
    }

    public enum SpellType
    {
        Attack,
        Barrier,
        Regeneration,
        Fireball,
        Cleansing
    }
}