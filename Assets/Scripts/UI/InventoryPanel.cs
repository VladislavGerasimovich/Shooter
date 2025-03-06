using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(PanelsCanvasGroup))]
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private Transform _panel;
        [SerializeField] private Transform _gameOverPanel;

        private PanelsCanvasGroup _panelsCanvasGroup;

        private void Awake()
        {
            _panelsCanvasGroup = GetComponent<PanelsCanvasGroup>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if(_gameOverPanel.gameObject.activeInHierarchy == true)
                {
                    return;
                }
                else if (_panel.gameObject.activeInHierarchy == true)
                {
                    _panelsCanvasGroup.Off();
                    _panel.gameObject.SetActive(false);

                    return;
                }

                _panelsCanvasGroup.On();
                _panel.gameObject.SetActive(true);
            }
        }
    }
}