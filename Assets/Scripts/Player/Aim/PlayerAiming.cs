using UnityEngine;

namespace Player.Aim
{
    public class PlayerAiming : MonoBehaviour
    {
        [SerializeField] private Transform _weaponTransform;
        [SerializeField] private Vector3 _newWeaponPosition;
        [SerializeField] private Transform _simpleCrosshair;
        [SerializeField] private Transform _aimingCrosshair;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _weaponTransform.localPosition = _newWeaponPosition;
                _simpleCrosshair.gameObject.SetActive(false);
                _aimingCrosshair.gameObject.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                _weaponTransform.localPosition = Vector3.zero;
                _simpleCrosshair.gameObject.SetActive(true);
                _aimingCrosshair.gameObject.SetActive(false);
            }
        }
    }
}