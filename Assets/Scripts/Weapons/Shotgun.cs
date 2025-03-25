using Health;
using ShakeAndRecoil;
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
        [SerializeField] private AudioSource _shootSound;
        [SerializeField] private Transform _decal;
        [SerializeField] private float _bulletDiameter;
        [SerializeField] private float _decalOffset;
        [SerializeField] private ShootEffect _shootEffect;
        [SerializeField] private CameraShakeAndRecoil _cameraShake;

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
            if(_attackDelay.CanAttack == true && _weaponAmmo.CanShoot == true)
            {
                _shootSound.Play();
                _weaponAmmo.Subtract();
                bool isHit = Physics.SphereCast(
                    startpoint,
                    _bulletDiameter,
                    direction,
                    out RaycastHit hitInfo,
                    _maxDistance,
                    _layerMask,
                    QueryTriggerInteraction.Ignore);

                if(isHit == true)
                {
                    var decal = Instantiate(_decal, hitInfo.transform);
                    decal.position = hitInfo.point + hitInfo.normal * _decalOffset;
                    decal.LookAt(hitInfo.point);
                    decal.Rotate(Vector3.up, 180, Space.Self);
                    _shootEffect.Perform();
                    AbstractHealth health = hitInfo.collider.GetComponentInParent<AbstractHealth>();

                    if(health != null)
                    {
                        health.TakeDamage(_damage);
                    }
                }

                _cameraShake.MakeRecoil();
                _attackDelay.Run();
            }
        }
    }
}