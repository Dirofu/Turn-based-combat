namespace Server
{
    public class SpellsGetter
    {
        public string GetSpell(SpellType type)
        {
            Spell spell = null;

            switch (type)
            {
                case SpellType.Attack:
                    spell = new Attack();
                    break;
                case SpellType.Barrier:
                    spell = new Barrier();
                    break;
                case SpellType.Regeneration:
                    spell = new Regeneration();
                    break;
                case SpellType.Fireball:
                    spell = new Fireball();
                    break;
                case SpellType.Cleansing:
                    spell = new Cleansing();
                    break;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(spell);
        }
    }
}
