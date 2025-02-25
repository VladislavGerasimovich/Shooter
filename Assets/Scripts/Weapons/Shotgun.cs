using UnityEngine;

namespace Weapons
{
    public class Shotgun : Weapon
    {
        [SerializeField] private float _damage = 10;

        public override void Shoot(Vector3 startpoint, Vector3 direction)
        {
            
        }
    }
}