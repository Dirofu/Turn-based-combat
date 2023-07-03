namespace Server
{
    public class Spell
    {
        public int Duration { get; protected set; }
        public int Cooldown { get; protected set; }
        public int PowerOnStep { get; protected set; }
        public int Value { get; protected set; }
        public SpellType Type { get; protected set; }
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