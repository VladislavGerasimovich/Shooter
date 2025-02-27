using Enemies.Chase;
using Enemies.Movement;
using Player.Movement;
using UnityEngine;

namespace Enemies.Observ
{
    public class EnemyObserv : MonoBehaviour
    {
        [SerializeField] private EnemyChasing _enemyChasing;
        [SerializeField] private EnemyPatrolling _enemyPatrolling;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovement playerMovement))
            {
                _enemyPatrolling.StopPatrolling();
                _enemyChasing.Run(playerMovement.transform);
            }
        }
    }
}