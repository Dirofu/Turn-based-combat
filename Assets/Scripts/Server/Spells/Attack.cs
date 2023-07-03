namespace Server
{
    public class Attack : Spell
    {
        public Attack()
        {
            Duration = 0;
            Cooldown = 0;
            PowerOnStep = 0;
            Value = 8;
            Type = SpellType.Attack;
        }
    }
}