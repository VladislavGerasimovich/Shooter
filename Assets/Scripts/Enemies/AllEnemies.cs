using Animations.Enemies;
using Enemies.Attack;
using Enemies.Chase;
using Enemies.Movement;
using Health;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Enemies
{
    public class AllEnemies : MonoBehaviour
    {
        [SerializeField] private List<EnemyMovement> _enemiesMovement;
        [SerializeField] private GameOverPanel _gameOverPanel;

        private List<EnemyHealth> _enemiesHealth;

        private void Awake()
        {
            _enemiesHealth = new List<EnemyHealth>();

            foreach (EnemyMovement enemy in _enemiesMovement)
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                _enemiesHealth.Add(enemyHealth);
            }
        }

        private void OnEnable()
        {
            foreach (EnemyHealth enemyHealth in _enemiesHealth)
            {
                enemyHealth.Died += OnEnemyDied;
            }
        }

        private void OnDisable()
        {
            foreach (EnemyHealth enemyHealth in _enemiesHealth)
            {
                enemyHealth.Died -= OnEnemyDied;
            }
        }

        public void SetInitialValues()
        {
            foreach (EnemyMovement enemyMovement in _enemiesMovement)
            {
                EnemyPatrolling enemyPatrolling = enemyMovement.GetComponent<EnemyPatrolling>();
                enemyPatrolling.StopPatrolling();
                EnemyHealth enemyHealth = enemyMovement.GetComponent<EnemyHealth>();
                enemyHealth.Restore();
                enemyMovement.SetPosition();
                EnemyAttack enemyAttack = enemyMovement.GetComponent<EnemyAttack>();
                enemyAttack.StopAttack();
                EnemyChasing enemyChasing = enemyMovement.GetComponent<EnemyChasing>();
                enemyChasing.StopChase();
                EnemyAnimations enemyAnimations = enemyMovement.GetComponent<EnemyAnimations>();
                enemyAnimations.Idle();
                enemyPatrolling.StartPatrolling();
            }
        }

        private void OnEnemyDied()
        {
            foreach (EnemyHealth enemyHealth in _enemiesHealth)
            {
                if(enemyHealth.CurrentHealth > 0)
                {
                    return;
                }
            }

            _gameOverPanel.On();
        }
    }
}