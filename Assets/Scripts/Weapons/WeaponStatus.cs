using UnityEngine;

namespace Weapons
{
    public class WeaponStatus : MonoBehaviour
    {
        public bool IsActive { get; private set; }

        public void OnWeapon()
        {
            IsActive = true;
        }

        public void OffWeapon()
        {
            IsActive = false;
        }
    }
}