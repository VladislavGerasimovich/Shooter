using UnityEngine;

namespace Collisions
{
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] private float _damage = 10;

        public float Damage => _damage;
    }
}