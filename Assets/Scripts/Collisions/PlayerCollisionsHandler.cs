using Enemies.Attack;
using Health;
using Objects3d;
using UnityEngine;
using Weapons;

namespace Collisions
{
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerCollisionsHandler : MonoBehaviour
    {
        [SerializeField] private WeaponAmmo _weaponAmmo;

        private PlayerHealth _playerHealth;

        private void Awake()
        {
            _playerHealth = GetComponent<PlayerHealth>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyAttack enemyAttack))
            {
                Debug.Log("collision");
                _playerHealth.TakeDamage(enemyAttack.Damage);
            }

            if (other.TryGetComponent(out Object3d object3d))
            {
                if(object3d.Type == Constants.Ammo)
                {
                    _weaponAmmo.Add(object3d.Count);
                    object3d.Destroy();
                }
                else if (object3d.Type == Constants.Health)
                {
                    if(_playerHealth.CurrentHealth < _playerHealth.MaxHealth)
                    {
                        _playerHealth.Add(object3d.Count);
                        object3d.Destroy();
                    }
                }
            }
        }
    }
}