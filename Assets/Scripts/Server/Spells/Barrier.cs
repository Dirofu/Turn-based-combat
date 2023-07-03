namespace Server
{
    public class Barrier : Spell
    {
        public Barrier()
        {
            Duration = 2;
            Cooldown = 4;
            PowerOnStep = 0;
            Value = 5;
            Type = SpellType.Barrier;
        }
    }
}