using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class PlayerHealth : AbstractHealth
    {
        [SerializeField] private float _maxHealth;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth => Health;

        private void Awake()
        {
            Health = _maxHealth;
        }

        public void Add(int value)
        {
            Health += value;

            if(Health > _maxHealth)
            {
                Health = _maxHealth;
            }
            Debug.Log(Health);
        }

        public override void Die()
        {
            Debug.Log("player died");
        }
    }
}