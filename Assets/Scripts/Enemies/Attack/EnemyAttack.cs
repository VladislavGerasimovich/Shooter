using Animations.Enemies;
using System.Collections;
using UnityEngine;

namespace Enemies.Attack
{
    [RequireComponent(typeof(Collider))]
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _damage = 11;
        [SerializeField] private EnemyAnimations _enemyAnimations;
        [SerializeField] private float _timeOfColliderEnabled = 0.3f;
        [SerializeField] private float _delayAfterAttack;

        bool _isAttacked;
        private Collider _attackCollider;

        public float Damage => _damage;

        public Coroutine AttackCoroutine { get; private set; }

        private void Awake()
        {
            _attackCollider = GetComponent<Collider>();
        }

        public void Run()
        {
            AttackCoroutine = StartCoroutine(Attack());
        }

        public void StopAttack()
        {
            if(AttackCoroutine != null)
            {
                _isAttacked = false;
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