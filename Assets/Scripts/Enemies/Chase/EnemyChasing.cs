using Animations.Enemies;
using Enemies.Attack;
using Enemies.Movement;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Enemies.Chase
{
    [RequireComponent(typeof(EnemyAnimations))]
    [RequireComponent(typeof(EnemyMovement))]
    public class EnemyChasing : MonoBehaviour
    {
        [SerializeField] private EnemyAttack _enemyAttack;

        private EnemyAnimations _enemyAnimations;
        private EnemyMovement _enemyMovement;
        private Transform _target;
        private Coroutine _chaseCoroutine;
        private bool _isChased;

        private void Awake()
        {
            _enemyAnimations = GetComponent<EnemyAnimations>();
            _enemyMovement = GetComponent<EnemyMovement>();
        }

        public void Run(Transform target)
        {
            if(_chaseCoroutine == null)
            {
                _target = target;
                _chaseCoroutine = StartCoroutine(Chase());
            }
        }

        public void StopChase()
        {
            if(_chaseCoroutine != null)
            {
                _isChased = false;
                _enemyAttack.StopAttack();
                _chaseCoroutine = null;
            }
        }

        private IEnumerator Chase()
        {
            _enemyAnimations.Run();
            _isChased = true;

            while (_isChased == true)
            {
                _enemyMovement.Move(_target);

                if (Vector3.Distance(transform.position, _target.position) < 0.5f)
                {
                    _enemyAttack.Run();

                    while(_enemyAttack.AttackCoroutine != null)
                    {
                        if (Vector3.Distance(transform.position, _target.position) > 0.8f)
                        {
                            _enemyAttack.StopAttack();
                        }
                        
                        yield return null;
                    }
                }

                yield return null;
            }
        }
    }
}