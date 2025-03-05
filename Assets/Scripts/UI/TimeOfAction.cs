using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TimeOfAction : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private Coroutine _runCoroutine;

        public void StartRunCoroutine(float time)
        {
            _runCoroutine = StartCoroutine(Run(time));
        }

        public void StopRunCoroutine()
        {
            StopCoroutine(_runCoroutine);
            _image.fillAmount = 0;
        }

        private IEnumerator Run(float time)
        {
            _image.fillAmount = 0;
            float duration = 0;

            while (_image.fillAmount < 1)
            {
                duration += Time.deltaTime;
                _image.fillAmount = duration / time;

                yield return null;
            }

            _image.fillAmount = 0;
        }
    }
}