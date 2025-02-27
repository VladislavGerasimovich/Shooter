using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected float _delay;

        public abstract void Shoot(Vector3 startpoint, Vector3 direction);
    }
}