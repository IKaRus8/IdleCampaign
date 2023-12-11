using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Services
{
    public class HealthSystem
    {
        private float _healthMax;
        private float _currentHealth;

        public HealthSystem(float healthMax)
        {
            _healthMax = healthMax;
            _currentHealth = healthMax;
        }
        public float GetHealth()
        {
            return _currentHealth;
        }
        public void TakeDamage(float damageAmount)
        {
            _currentHealth -= damageAmount;
            if(_currentHealth<=0)
            {
                _currentHealth = 0;
                //dead
            }
        }
    }
}
