namespace Server
{
    public class Fireball : Spell
    {
        public Fireball()
        {
            Duration = 5;
            Cooldown = 6;
            PowerOnStep = 1;
            Value = 5;
            Type = SpellType.Fireball;
        }
    }
}