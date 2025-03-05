using Player.Shoot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(PlayerShoot))]
    public class PlayerWeapons : MonoBehaviour
    {
        [SerializeField] private Weapon _pistol;
        [SerializeField] private Weapon _shotGun;
        [SerializeField] private AmmoCountView _ammoCountView;

        private PlayerShoot _playerShoot;

        private void Awake()
        {
            _playerShoot = GetComponent<PlayerShoot>();
        }

        private void Start()
        {
            Swap(_pistol);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Swap(_pistol);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Swap(_shotGun);
            }
        }

        private void Swap(Weapon weapon)
        {
            _playerShoot.SwapWeapon(weapon);
            WeaponAmmo weaponAmmo = weapon.GetComponent<WeaponAmmo>();
            WeaponStatus weaponStatus = weapon.GetComponent<WeaponStatus>();
            weaponStatus.OnWeapon();
            _ammoCountView.Set(weaponAmmo.AmmoInMagazine, weaponAmmo.CurrentAmmoCount);
        }
    }
}