using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(PanelsCanvasGroup))]
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Transform _panel;
        [SerializeField] private Button _restartButton;

        private PanelsCanvasGroup _panelsCanvasGroup;

        private void Awake()
        {
            _panelsCanvasGroup = GetComponent<PanelsCanvasGroup>();
        }

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(Off);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(Off);
        }

        public void On()
        {
            _panelsCanvasGroup.On();
            _panel.gameObject.SetActive(true);
        }

        public void Off()
        {
            _panelsCanvasGroup.Off();
            _panel.gameObject.SetActive(false);
        }
    }
}