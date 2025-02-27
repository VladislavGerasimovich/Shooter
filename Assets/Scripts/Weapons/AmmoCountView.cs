using TMPro;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(TMP_Text))]
    public class AmmoCountView : MonoBehaviour
    {
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        public void Set(int ammoInMagazine, int currentAmmoCount)
        {
            _text.text = $"{ammoInMagazine} / {currentAmmoCount}";
        }
    }
}