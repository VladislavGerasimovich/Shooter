using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Health
{
    public class PlayerHealth : AbstractHealth
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private TMP_Text _text;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth => Health;

        private void Awake()
        {
            Health = _maxHealth;
            _text.text = Health.ToString();
        }

        public void Add(int value)
        {
            Health += value;

            if(Health > _maxHealth)
            {
                Health = _maxHealth;
            }

            _text.text = Health.ToString();
        }

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            _text.text = Health.ToString();
        }

        public override void Die()
        {
            Debug.Log("player died");
        }
    }
}