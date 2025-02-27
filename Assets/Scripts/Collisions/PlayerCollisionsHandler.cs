using Enemies.Attack;
using Health;
using UnityEngine;

namespace Collisions
{
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerCollisionsHandler : MonoBehaviour
    {
        private PlayerHealth _playerHealth;

        private void Awake()
        {
            _playerHealth = GetComponent<PlayerHealth>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyAttack enemyAttack))
            {
                Debug.Log("collision");
                _playerHealth.TakeDamage(enemyAttack.Damage);
            }
        }
    }
}