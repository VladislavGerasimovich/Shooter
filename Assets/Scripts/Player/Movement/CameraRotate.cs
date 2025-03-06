using UI;
using UnityEngine;

namespace Player.Movement
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private float _verticalTurnSensitivity = 10f;
        [SerializeField] private float _verticalMinAngle = -89;
        [SerializeField] private float _verticalMaxAngle = 89;
        [SerializeField] private PanelsCanvasGroup _inventoryPanel;

        private float _cameraAngle = 0;

        private void Awake()
        {
            _cameraAngle = transform.localEulerAngles.x;
        }

        private void Update()
        {
            if(_inventoryPanel.IsOpen == false)
            {
                _cameraAngle -= Input.GetAxis(Constants.VerticalMouseAxis) * _verticalTurnSensitivity;
                _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
                transform.localEulerAngles = Vector3.right * _cameraAngle;
            }
        }
    }
}