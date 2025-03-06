using System.Collections;
using UnityEngine;

namespace Objects3d
{
    public class ObjectRotate : MonoBehaviour
    {
        private bool _isWorking;

        private void Start()
        {
            StartRotate();
        }

        public void StartRotate()
        {
            if (_isWorking == false)
            {
                _isWorking = true;
                StartCoroutine(RotateCoroutine());
            }
        }

        public void StopRotate()
        {
            _isWorking = false;
            StopCoroutine(RotateCoroutine());
        }

        private IEnumerator RotateCoroutine()
        {
            while (_isWorking == true)
            {
                transform.Rotate(Vector3.up, 0.5f);

                yield return null;
            }
        }
    }
}