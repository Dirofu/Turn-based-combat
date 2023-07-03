namespace Server
{
    public class WebCharacterHealth
    {
        private float _health = 50;
        private float _maxHealth = 50;

        private float _barrierHealth = 0;

        public void GetHealth(out float health, out float maxHealth)
        {
            health = _health;
            maxHealth = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (_barrierHealth > 0)
                damage = AffectDamage(damage);

            if (damage < 0)
                return;

            _health -= damage;
        }

        public void AddHealth(float health)
        {
            if (health < 0)
                return;

            _health += health;
        }

        public void EnableBarrier(float value) => _barrierHealth = value;
        public void DisableBarrier() => _barrierHealth = 0;

        private float AffectDamage(float damage)
        {
            float tempValue;

            if (_barrierHealth >= damage)
            {
                tempValue = _barrierHealth - damage;
                return 0;
            }
            else
            {
                tempValue = damage - _barrierHealth;
                return tempValue;
            }
        }
    }
}
