using UnityEngine;

namespace UI.Grid.Items
{
    [CreateAssetMenu(fileName = "New ItemData", menuName = "WeaponAmmo", order = 51)]
    public class Ammo : Item
    {
        [SerializeField] private string _type;
        [SerializeField] private int _maxAmount;
        [SerializeField] private int _currentAmount;

        public string Type => _type;
        public int CurrentAmount => _currentAmount;

        public void SubtractAmount()
        {
            _currentAmount--;
        }

        public void AddAmout(int amount)
        {
            _currentAmount += amount;

            if(_currentAmount > _maxAmount)
            {
                _currentAmount = _maxAmount;
            }
        }
    }
}