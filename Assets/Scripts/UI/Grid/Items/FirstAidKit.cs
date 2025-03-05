using UnityEngine;

namespace UI.Grid.Items
{
    [CreateAssetMenu(fileName = "New ItemData", menuName = "FirstAidKit", order = 51)]
    public class FirstAidKit : Ammo
    {
        [SerializeField] private int _healthRestoredCount;

        public int HealthRestoredCount => _healthRestoredCount;
    }
}