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
        [SerializeField] private WeaponAmmo _pistolAmmo;
        [SerializeField] private WeaponAmmo _shotgunAmmo;

        private PlayerHealth _playerHealth;

        private void Awake()
        {
            _playerHealth = GetComponent<PlayerHealth>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyDamage enemyDamage))
            {
                _playerHealth.TakeDamage(enemyDamage.Damage);
            }

            if (other.TryGetComponent(out Object3d object3d))
            {
                if (object3d.Type == Constants.PistolAmmo)
                {
                    AddWeaponAmmo(_pistolAmmo, object3d);
                }
                else if (object3d.Type == Constants.ShotgunAmmo)
                {
                    AddWeaponAmmo(_shotgunAmmo, object3d);
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

        private void AddWeaponAmmo(WeaponAmmo weapon, Object3d object3d)
        {
            bool canAddAmmo = weapon.MaxAmmo > (weapon.CurrentAmmoCount + weapon.AmmoInMagazine);

            if (canAddAmmo == true)
            {
                weapon.Add(object3d.Count);
                object3d.Destroy();
            }
        }
    }
}