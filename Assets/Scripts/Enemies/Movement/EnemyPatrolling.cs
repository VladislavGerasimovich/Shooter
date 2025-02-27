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

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyAnimations = GetComponent<EnemyAnimations>();
            _points = new Transform[_path.childCount];

            for (int i = 0; i < _path.childCount; i++)
            {
                _points[i] = _path.GetChild(i);
            }

            StartCoroutine(MoveBetweenPoints());
        }

        public void StopPatrolling()
        {
            _isWork = false;
        }

        private IEnumerator MoveBetweenPoints()
        {
            _enemyAnimations.Walk();
            _isWork = true;

            while (_isWork == true)
            {
                Transform target = _points[_currentPoint];
                _enemyMovement.Move(target);

                if (transform.position == target.position)
                {
                    _enemyAnimations.Idle();

                    yield return new WaitForSeconds(3);

                    _enemyAnimations.Walk();
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