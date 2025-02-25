using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerJump))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _strafeSpeed = 3f;
        [SerializeField] private Transform _cameraTransform;

        private Vector3 _verticalVelocity;
        private CharacterController _characterController;
        private PlayerJump _playerJump;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerJump = GetComponent<PlayerJump>();
        }

        private void Update()
        {
            Vector3 forward = ProjectOnPlane(_cameraTransform.forward);
            Vector3 right = ProjectOnPlane(_cameraTransform.right);

            if (_characterController != null)
            {
                Vector3 playerSpeed = forward * Input.GetAxis(Constants.VerticalAxis) * _speed
                    + right * Input.GetAxis(Constants.HorizontalAxis) * _strafeSpeed;

                if (_characterController.isGrounded)
                {
                    _playerJump.Flying();
                    _verticalVelocity = _playerJump.VerticalVelocity;
                    _characterController.Move((playerSpeed + _verticalVelocity) * Time.deltaTime);
                }
                else
                {
                    Debug.Log("падает");
                    Vector3 horizontalVelocity = _characterController.velocity;
                    horizontalVelocity.y = 0;
                    _playerJump.Falling();
                    _verticalVelocity = _playerJump.VerticalVelocity;
                    _characterController.Move((horizontalVelocity + _verticalVelocity) * Time.deltaTime);
                }
            }
        }

        private Vector3 ProjectOnPlane(Vector3 vector)
        {
            return Vector3.ProjectOnPlane(vector, Vector3.up).normalized;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var character = GetComponent<CharacterController>();

            Gizmos.DrawWireCube(transform.position, Vector3.right + Vector3.forward + Vector3.up * character.height);
        }
    }
}