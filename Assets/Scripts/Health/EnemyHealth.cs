using Animations.Enemies;
using Enemies.Chase;
using Enemies.Movement;
using Enemies.Observ;
using System;
using System.Collections;
using UnityEngine;

namespace Health
{
    [RequireComponent(typeof(EnemyChasing))]
    [RequireComponent(typeof(EnemyPatrolling))]
    [RequireComponent(typeof(EnemyAnimations))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class EnemyHealth : AbstractHealth
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private EnemyObserv _enemyObserv;
        [SerializeField] private Collider _attackCollider;

        private EnemyChasing _enemyChasing;
        private EnemyPatrolling _enemyPatrolling;
        private EnemyAnimations _enemyAnimations;
        private Rigidbody _rigidbody;
        private Collider _collider;

        public event Action Died;

        public float CurrentHealth => Health;

        private void Awake()
        {
            _enemyChasing = GetComponent<EnemyChasing>();
            _enemyPatrolling = GetComponent<EnemyPatrolling>();
            _enemyAnimations = GetComponent<EnemyAnimations>();
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public override void Die()
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.isKinematic = true;
            _enemyObserv.gameObject.SetActive(false);
            _collider.enabled = false;
            _attackCollider.enabled = false;
            _enemyChasing.StopChase();
            _enemyPatrolling.StopPatrolling();
            _enemyAnimations.Died();
            Died?.Invoke();
        }

        public void Restore()
        {
            Health = _maxHealth;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _rigidbody.isKinematic = false;
            _enemyObserv.gameObject.SetActive(true);
            _collider.enabled = true;
            _attackCollider.enabled = true;
        }
    }
}