using UnityEngine;

namespace Enemies.Movement
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        public void Move(Transform target)
        {
            transform.LookAt(target.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        }
    }
}