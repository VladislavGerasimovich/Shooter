using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InventoryPanel : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        public bool IsOpen { get; private set; }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwitchPanel();
            }
        }

        private void SwitchPanel()
        {
            IsOpen = _canvasGroup.alpha == 1 ? false : true;
            _canvasGroup.blocksRaycasts = _canvasGroup.alpha == 1 ? false : true;
            _canvasGroup.alpha = _canvasGroup.alpha == 1 ? 0 : 1;
        }
    }
}