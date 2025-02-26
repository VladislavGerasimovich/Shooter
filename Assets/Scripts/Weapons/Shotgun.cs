using Health;
using UnityEngine;

namespace Weapons
{
    public class Shotgun : Weapon
    {
        [SerializeField] private float _damage = 10;
        [SerializeField] private float _maxDistance = 500f;
        [SerializeField] private LayerMask _layerMask;

        public override void Shoot(Vector3 startpoint, Vector3 direction)
        {
            bool isHit = Physics.Raycast(startpoint, direction, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore);

            if(isHit == true)
            {
                AbstractHealth health = hitInfo.collider.GetComponentInParent<AbstractHealth>();

                if(health != null)
                {
                    health.TakeDamage(_damage);
                }
            }
        }
    }
}