namespace Server
{
    public class Regeneration : Spell
    {
        public Regeneration()
        {
            Duration = 2;
            Cooldown = 5;
            PowerOnStep = 2;
            Value = 0;
            Type = SpellType.Regeneration;
        }
    }
}