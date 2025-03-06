using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(PanelsCanvasGroup))]
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Transform _panel;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameTime _gameTime;
        [SerializeField] private GameSession _gameSession;

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
            //_gameTime.Stop();
            _panelsCanvasGroup.On();
            _panel.gameObject.SetActive(true);
        }

        public void Off()
        {
            _gameSession.Restart();
            _gameTime.Run();
            _panelsCanvasGroup.Off();
            _panel.gameObject.SetActive(false);
        }
    }
}