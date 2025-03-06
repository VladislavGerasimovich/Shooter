using Animations.Enemies;
using System.Collections;
using UnityEngine;

namespace Enemies.Movement
{
    [RequireComponent(typeof (EnemyMovement))]
    [RequireComponent(typeof (EnemyAnimations))]
    public class EnemyPatrolling : MonoBehaviour
    {
        [SerializeField] private Transform _path;

        private EnemyMovement _enemyMovement;
        private EnemyAnimations _enemyAnimations;
        private Transform[] _points;
        private int _currentPoint;
        private bool _isWork;
        private Coroutine _patrolCoroutine;

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyAnimations = GetComponent<EnemyAnimations>();
            _points = new Transform[_path.childCount];

            for (int i = 0; i < _path.childCount; i++)
            {
                _points[i] = _path.GetChild(i);
            }
        }

        private void Start()
        {
            StartPatrolling();
        }

        public void StartPatrolling()
        {
            if(_patrolCoroutine == null)
            {
                _patrolCoroutine = StartCoroutine(MoveBetweenPoints());
            }
        }

        public void StopPatrolling()
        {
            if(_patrolCoroutine != null)
            {
                _patrolCoroutine = null;
                StopCoroutine(MoveBetweenPoints());
                _isWork = false;
            }
        }

        private IEnumerator MoveBetweenPoints()
        {
            _currentPoint = 0;
            _enemyAnimations.Walk();
            _isWork = true;

            while (_isWork == true)
            {
                Transform target = _points[_currentPoint];
                _enemyMovement.Move(target);

                if (transform.position == target.position)
                {
                    _currentPoint++;

                    if (_currentPoint >= _points.Length)
                    {
                        _currentPoint = 0;
                    }
                }

                yield return null;
            }
        }
    }
}