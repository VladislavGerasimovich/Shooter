using UnityEngine;

namespace Health
{
    public abstract class AbstractHealth : MonoBehaviour
    {
        [SerializeField] protected float Health;

        public virtual void TakeDamage(float damage)
        {
            if(damage < 0)
            {
                return;
            }

            if(Health < 0)
            {
                return;
            }

            Health -= damage;

            if(Health <= 0)
            {
                Health = 0;
                Die();
            }
        }

        public abstract void Die();
    }
}