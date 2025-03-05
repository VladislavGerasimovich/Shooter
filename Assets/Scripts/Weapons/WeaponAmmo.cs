using System.Collections;
using UI;
using UI.Grid;
using UI.Grid.Items;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(WeaponStatus))]
    public class WeaponAmmo : MonoBehaviour
    {
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private int _maxAmmoInMagazine;
        [SerializeField] private AmmoCountView _ammoCountView;
        [SerializeField] private TimeOfAction _timeOfAction;
        [SerializeField] private Ammo _ammo;
        [SerializeField] private UIAmmoViews _ammoViews;
        [SerializeField] private InventoryPanel _inventoryPanel;

        private WeaponStatus _weaponStatus;
        private Coroutine _reloadCoroutine;
        private UIItemView _itemView;

        public int CurrentAmmoCount { get; private set; }
        public int AmmoInMagazine { get; private set; }
        public bool CanShoot { get; private set; }

        public int MaxAmmo => _maxAmmo;

        private void Awake()
        {
            CurrentAmmoCount = _ammo.CurrentAmount;
            _weaponStatus = GetComponent<WeaponStatus>();

            if (CurrentAmmoCount > _maxAmmoInMagazine)
            {
                AmmoInMagazine = _maxAmmoInMagazine;
            }
            else if(CurrentAmmoCount < _maxAmmoInMagazine)
            {
                AmmoInMagazine = CurrentAmmoCount;
            }

            CurrentAmmoCount -= AmmoInMagazine;

            if(CurrentAmmoCount < 0)
            {
                CurrentAmmoCount = 0;
            }

            if(CurrentAmmoCount == 0 && AmmoInMagazine == 0)
            {
                return;
            }

            CanShoot = true;
        }

        private void Start()
        {
            _itemView = _ammoViews.Get(_ammo.Type);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (
                    _reloadCoroutine == null &&
                    AmmoInMagazine < _maxAmmoInMagazine &&
                    CurrentAmmoCount > 0 &&
                    _weaponStatus.IsActive == true)
                {
                    Debug.Log("reloaddd");
                   _reloadCoroutine = StartCoroutine(Reload());
                }
            }
        }

        public void Add(int value)
        {
            int allCurrentAmmoCount = CurrentAmmoCount + AmmoInMagazine;

            if (allCurrentAmmoCount < _maxAmmo)
            {
                if(value > (_maxAmmo - CurrentAmmoCount))
                {
                    CurrentAmmoCount = _maxAmmo - AmmoInMagazine;
                    _ammo.AddAmout(value);
                    _itemView.Set(_ammo.Icon, _ammo.CurrentAmount);
                    SetView();

                    return;
                }

                CurrentAmmoCount += value;
                _ammo.AddAmout(value);
                _itemView.Set(_ammo.Icon, _ammo.CurrentAmount);
                SetView();
            }
        }

        public void Subtract()
        {
            _ammo.SubtractAmount();
            _itemView.Set(_ammo.Icon, _ammo.CurrentAmount);
            AmmoInMagazine--;
            _ammoCountView.Set(AmmoInMagazine, CurrentAmmoCount);

            if (AmmoInMagazine == 0 && CurrentAmmoCount > 0)
            {
                if(AmmoInMagazine < _maxAmmoInMagazine && CurrentAmmoCount > 0)
                {
                    _reloadCoroutine = StartCoroutine(Reload());

                    return;
                }
            }

            if (CurrentAmmoCount == 0 && AmmoInMagazine == 0)
            {
                CanShoot = false;
            }
        }

        public void StopReload()
        {
            if (_reloadCoroutine != null)
            {
                StopCoroutine(_reloadCoroutine);
                _timeOfAction.StopRunCoroutine();
                _reloadCoroutine = null;
            }
        }

        private void SetView()
        {
            if (_weaponStatus.IsActive == true)
            {
                _ammoCountView.Set(AmmoInMagazine, CurrentAmmoCount);
            }
        }

        private IEnumerator Reload()
        {
            if(_inventoryPanel.IsOpen == false)
            {
                CanShoot = false;
                _timeOfAction.StartRunCoroutine(_reloadTime);

                yield return new WaitForSeconds(_reloadTime);

                int requiredAmmoCount = _maxAmmoInMagazine - AmmoInMagazine;

                if(requiredAmmoCount >= CurrentAmmoCount)
                {
                    AmmoInMagazine += CurrentAmmoCount;
                    CurrentAmmoCount = 0;
                }
                else if(requiredAmmoCount < CurrentAmmoCount)
                {
                    CurrentAmmoCount -= requiredAmmoCount;
                    AmmoInMagazine += requiredAmmoCount;
                }

                _ammoCountView.Set(AmmoInMagazine, CurrentAmmoCount);
                _reloadCoroutine = null;
                CanShoot = true;
            }
        }
    }
}