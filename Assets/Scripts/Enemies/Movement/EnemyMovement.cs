using UnityEngine;

namespace Enemies.Movement
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private Vector3 _startPosition;

        public void Move(Transform target)
        {
            transform.LookAt(target.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        }

        public void SetPosition()
        {
            transform.position = _startPosition;
        }
    }
}