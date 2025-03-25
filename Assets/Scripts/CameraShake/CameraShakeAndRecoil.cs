using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

namespace ShakeAndRecoil
{
    public class CameraShakeAndRecoil : MonoBehaviour
    {
        [Header("Noise")]
        [SerializeField] private Transform _camera;
        [SerializeField] private float _perlinNoiseTimeScale;
        [SerializeField] private AnimationCurve _perlinNoiseAmplitudeCurve;

        [Header("Recoil")]
        [SerializeField] private float _tension;
        [SerializeField] private float _damping;
        [SerializeField] private float _impulse;

        private Vector3 _shakeAngles;
        private Vector3 _recoilAngles;
        private Vector3 _recoilVelocity;
        private float _amplitude;
        private float _duration;
        private float _shakeTimer;
        private float _verticalDivider;
        private float _impulseMultiplier;

        private void Awake()
        {
            _shakeAngles = new Vector3();
            _recoilAngles = new Vector3();
            _recoilVelocity = new Vector3();
            _amplitude = 15f;
            _duration = 3f;
            _shakeTimer = -1f;
            _verticalDivider = 4f;
            _impulseMultiplier = 0.05f;
        }

        private void Update()
        {
            UpdateShake();
            UpdateRecoil();
            _camera.localEulerAngles += _shakeAngles + _recoilAngles;
        }

        private void UpdateRecoil()
        {
            _recoilAngles += _recoilVelocity * Time.deltaTime;
            _recoilVelocity += -_recoilAngles * Time.deltaTime * _tension;
            _recoilVelocity = Vector3.Lerp(_recoilVelocity, Vector3.zero, Time.deltaTime * _damping);
        }

        private void UpdateShake()
        {
            if (_shakeTimer > 0)
            {
                _shakeTimer -= Time.deltaTime / _duration;
            }

            float time = Time.time * _perlinNoiseTimeScale;
            _shakeAngles.x = Mathf.PerlinNoise(time, 0);
            _shakeAngles.y = Mathf.PerlinNoise(0, time);
            _shakeAngles.z = Mathf.PerlinNoise(time, time);
            _shakeAngles *= _amplitude;
            _shakeAngles *= _perlinNoiseAmplitudeCurve.Evaluate(Mathf.Clamp01(1 - _shakeTimer));
        }

        [ProPlayButton]
        public void MakeShake()
        {
            _duration = Mathf.Max(_duration, 0,05f);
            _shakeTimer = 1;
        }

        public void MakeRecoil()
        {
            Vector3 impulse = -Vector3.right * UnityEngine.Random.Range(_impulse * _impulseMultiplier, _impulse)
                + Vector3.up * UnityEngine.Random.Range(-_impulse, _impulse) / _verticalDivider;
            _recoilVelocity += impulse;
        }
    }
}