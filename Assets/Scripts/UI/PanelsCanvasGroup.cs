using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PanelsCanvasGroup : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        public bool IsOpen { get; private set; }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void On()
        {
            IsOpen = true;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1;
        }

        public void Off()
        {
            IsOpen = false;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0;
        }
    }
}