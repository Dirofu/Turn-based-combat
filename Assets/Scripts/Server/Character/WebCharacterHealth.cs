namespace Server
{
    public class WebCharacterHealth
    {
        private float _health = 50;
        private float _maxHealth = 50;

        public void GetHealth(out float health, out float maxHealth)
        {
            health = _health;
            maxHealth = _maxHealth;
        }

        public bool TryTakeDamage(float damage)
        {
            if (damage < 0)
                return false;

            _health -= damage;

            return true;
        }
    }
}
