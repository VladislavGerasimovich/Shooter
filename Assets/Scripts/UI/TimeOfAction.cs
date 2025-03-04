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
        [SerializeField] private CanvasGroup _canvasGroup;

        public void StartRunCoroutine(float time)
        {
            StartCoroutine(Run(time));
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