using UnityEngine;

namespace Weapons
{
    public class ShootEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private AudioSource _shootSound;

        public void Perform()
        {
            _shootSound.Play();
            _particleSystem.Clear();
            _particleSystem.Play();
        }
    }
}