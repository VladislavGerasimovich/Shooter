using UnityEngine;
using Weapons;

namespace Player.Shoot
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Weapon _shotGun;
        [SerializeField] private Transform _cameraTransform;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Run();
            }
        }

        public void Run()
        {
            Debug.Log("Run");
            _shotGun.Shoot(_cameraTransform.position, _cameraTransform.forward);
        }
    }
}