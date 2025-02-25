using UnityEngine;

namespace Player.Movement
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private float _verticalTurnSensitivity = 10f;
        [SerializeField] private float _verticalMinAngle = -89;
        [SerializeField] private float _verticalMaxAngle = 89;

        private float _cameraAngle = 0;

        private void Awake()
        {
            _cameraAngle = transform.localEulerAngles.x;
        }

        private void Update()
        {
            _cameraAngle -= Input.GetAxis(Constants.VerticalMouseAxis) * _verticalTurnSensitivity;
            _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
            transform.localEulerAngles = Vector3.right * _cameraAngle;
        }
    }
}