using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraShake
{
    public class VisualizePerlin : MonoBehaviour
    {
        [SerializeField] private Texture2D _texture;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private float _perlinNoiseScale;
        [SerializeField] private int _textureWidth;

        private void Awake()
        {
            if (_texture == null)
            {
                _texture = new Texture2D(_textureWidth, _textureWidth);
            }

            _renderer.material.mainTexture = _texture;
        }

        private void Update()
        {
            for (int x = 0; x < _textureWidth; x++)
            {
                for (int y = 0; y < _textureWidth; y++)
                {
                    Color color = Color.Lerp(Color.black, Color.white, Mathf.PerlinNoise(x * _perlinNoiseScale, y * _perlinNoiseScale));
                    _texture.SetPixel(x, y, color);
                }
            }

            _texture.Apply();
        }
    }
}