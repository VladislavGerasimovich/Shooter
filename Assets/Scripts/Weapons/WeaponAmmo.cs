using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class WeaponAmmo : MonoBehaviour
    {
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private int _maxAmmoInMagazine;
        [SerializeField] private AmmoCountView _ammoCountView;

        private int _currentAmmoCount;
        private int _ammoInMagazine;

        public bool CanShoot { get; private set; }

        private void Awake()
        {
            _ammoInMagazine = _maxAmmoInMagazine;
            _currentAmmoCount = _maxAmmo - _maxAmmoInMagazine;
            CanShoot = true;
        }

        private void Start()
        {
            _ammoCountView.Set(_ammoInMagazine, _currentAmmoCount);
        }

        public void Set()
        {
            _ammoInMagazine--;
            _ammoCountView.Set(_ammoInMagazine, _currentAmmoCount);

            if(_ammoInMagazine == 0 && _currentAmmoCount > 0)
            {
                StartCoroutine(Reload());

                return;
            }

            if(_currentAmmoCount == 0)
            {
                CanShoot = false;
            }
        }

        private IEnumerator Reload()
        {
            CanShoot = false;

            yield return new WaitForSeconds(_reloadTime);

            CanShoot = true;

            if (_currentAmmoCount < _maxAmmoInMagazine)
            {
                _ammoInMagazine = _currentAmmoCount;
                _currentAmmoCount -= _ammoInMagazine;
            }

            if(_currentAmmoCount >= _maxAmmoInMagazine)
            {
                _ammoInMagazine = _maxAmmoInMagazine;
                _currentAmmoCount -= _ammoInMagazine;
            }

            _ammoCountView.Set(_ammoInMagazine, _currentAmmoCount);
        }
    }
}