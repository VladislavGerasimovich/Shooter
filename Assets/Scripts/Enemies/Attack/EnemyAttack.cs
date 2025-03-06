using Animations.Enemies;
using System.Collections;
using UnityEngine;

namespace Enemies.Attack
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimations _enemyAnimations;
        [SerializeField] private float _timeOfColliderEnabled = 0.3f;
        [SerializeField] private float _delayAfterAttack;
        [SerializeField] private Collider _attackCollider;

        bool _isAttacked;

        public Coroutine AttackCoroutine { get; private set; }

        public void Run()
        {
            if(AttackCoroutine == null)
            {
                AttackCoroutine = StartCoroutine(Attack());
            }
        }

        public void StopAttack()
        {
            if(AttackCoroutine != null)
            {
                _isAttacked = false;
                StopCoroutine(AttackCoroutine);
                AttackCoroutine = null;
                _enemyAnimations.Run();
            }
        }

        private IEnumerator Attack()
        {
            _enemyAnimations.FightIdle();
            _isAttacked = true;

            while (_isAttacked == true)
            {
                _enemyAnimations.Punch();
                _attackCollider.enabled = true;

                yield return new WaitForSeconds(_timeOfColliderEnabled);

                _attackCollider.enabled = false;

                yield return new WaitForSeconds(_delayAfterAttack);
            }
        }
    }
}