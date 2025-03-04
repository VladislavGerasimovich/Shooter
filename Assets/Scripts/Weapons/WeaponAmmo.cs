using System.Collections;
using UI;
using UnityEngine;

namespace Weapons
{
    public class WeaponAmmo : MonoBehaviour
    {
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private int _maxAmmoInMagazine;
        [SerializeField] private AmmoCountView _ammoCountView;
        [SerializeField] private TimeOfAction _timeOfAction;

        public int CurrentAmmoCount { get; private set; }
        public int AmmoInMagazine { get; private set; }
        public bool CanShoot { get; private set; }

        public int MaxAmmo => _maxAmmo;

        private void Awake()
        {
            AmmoInMagazine = _maxAmmoInMagazine;
            CurrentAmmoCount = _maxAmmo - _maxAmmoInMagazine;
            CanShoot = true;
        }

        private void Start()
        {
            _ammoCountView.Set(AmmoInMagazine, CurrentAmmoCount);
        }

        public void Add(int value)
        {
            int allCurrentAmmoCount = CurrentAmmoCount + AmmoInMagazine;

            if (allCurrentAmmoCount < _maxAmmo)
            {
                if(value > (_maxAmmo - CurrentAmmoCount))
                {
                    CurrentAmmoCount = _maxAmmo - AmmoInMagazine;
                    _ammoCountView.Set(AmmoInMagazine, CurrentAmmoCount);

                    return;
                }

                CurrentAmmoCount += value;
                _ammoCountView.Set(AmmoInMagazine, CurrentAmmoCount);
            }
        }

        public void Subtract()
        {
            AmmoInMagazine--;
            _ammoCountView.Set(AmmoInMagazine, CurrentAmmoCount);

            if(AmmoInMagazine == 0 && CurrentAmmoCount > 0)
            {
                StartCoroutine(Reload());

                return;
            }

            if(CurrentAmmoCount == 0)
            {
                CanShoot = false;
            }
        }

        private IEnumerator Reload()
        {
            CanShoot = false;

            _timeOfAction.StartRunCoroutine(_reloadTime);
            yield return new WaitForSeconds(_reloadTime);

            CanShoot = true;

            if (CurrentAmmoCount < _maxAmmoInMagazine)
            {
                AmmoInMagazine = CurrentAmmoCount;
                CurrentAmmoCount -= AmmoInMagazine;
            }

            if(CurrentAmmoCount >= _maxAmmoInMagazine)
            {
                AmmoInMagazine = _maxAmmoInMagazine;
                CurrentAmmoCount -= AmmoInMagazine;
            }

            _ammoCountView.Set(AmmoInMagazine, CurrentAmmoCount);
        }
    }
}