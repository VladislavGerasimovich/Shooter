using UI;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private float _horizontalTurnSensitivity = 10f;
        [SerializeField] private InventoryPanel _inventoryPanel;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            if(_inventoryPanel.IsOpen == false)
            {
                _transform.Rotate(Vector3.up * Input.GetAxis(Constants.HorizontalMouseAxis) * _horizontalTurnSensitivity);
            }
        }
    }
}