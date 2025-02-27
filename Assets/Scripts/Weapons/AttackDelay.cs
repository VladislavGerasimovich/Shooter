using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class AttackDelay : MonoBehaviour
    {
        private float _delay;

        public bool CanAttack { get; private set; }

        public void Init(float delay)
        {
            _delay = delay;
            CanAttack = true;
        }

        public void Run()
        {
            StartCoroutine(DelayCoroutine());
        }

        private IEnumerator DelayCoroutine()
        {
            CanAttack = false;

            yield return new WaitForSeconds(_delay);

            CanAttack = true;
        }
    }
}