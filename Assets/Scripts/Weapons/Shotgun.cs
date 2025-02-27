using Health;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(AttackDelay))]
    [RequireComponent(typeof(WeaponAmmo))]
    public class Shotgun : Weapon
    {
        [SerializeField] private float _damage = 10;
        [SerializeField] private float _maxDistance = 500f;
        [SerializeField] private LayerMask _layerMask;

        private AttackDelay _attackDelay;
        private WeaponAmmo _weaponAmmo;

        private void Awake()
        {
            _attackDelay = GetComponent<AttackDelay>();
            _weaponAmmo = GetComponent<WeaponAmmo>();
            _attackDelay.Init(_delay);
        }

        public override void Shoot(Vector3 startpoint, Vector3 direction)
        {
            Debug.Log(_weaponAmmo.CanShoot + " weapon ammo can shoot");
            if(_attackDelay.CanAttack == true && _weaponAmmo.CanShoot == true)
            {
                _weaponAmmo.Set();
                bool isHit = Physics.Raycast(
                    startpoint,
                    direction,
                    out RaycastHit hitInfo,
                    _maxDistance,
                    _layerMask,
                    QueryTriggerInteraction.Ignore);

                if(isHit == true)
                {
                    AbstractHealth health = hitInfo.collider.GetComponentInParent<AbstractHealth>();

                    if(health != null)
                    {
                        health.TakeDamage(_damage);
                    }
                }

                _attackDelay.Run();
            }
        }
    }
}