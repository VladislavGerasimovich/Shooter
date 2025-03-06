using UI;
using UnityEngine;
using Weapons;

namespace Player.Shoot
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private PanelsCanvasGroup _inventoryPanel;

        private Weapon _currentWeapon;

        private void Update()
        {
            if (_inventoryPanel.IsOpen == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Run();
                }
            }
        }

        public void SwapWeapon(Weapon weapon)
        {
            if (_currentWeapon != null)
            {
                WeaponAmmo _currentWeaponAmmo = _currentWeapon.GetComponent<WeaponAmmo>();
                WeaponStatus _currentWeaponStatus = _currentWeapon.GetComponent<WeaponStatus>();
                _currentWeaponStatus.OffWeapon();
                _currentWeaponAmmo.StopReload();
            }

            _currentWeapon = weapon;
        }

        public void Run()
        {
            _currentWeapon.Shoot(_cameraTransform.position, _cameraTransform.forward);
        }
    }
}