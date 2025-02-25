using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void Shoot(Vector3 startpoint, Vector3 direction);
    }
}