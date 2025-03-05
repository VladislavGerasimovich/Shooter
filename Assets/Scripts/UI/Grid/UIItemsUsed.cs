using System.Collections.Generic;
using UI.Grid.Items;
using UnityEngine;

namespace UI.Grid
{
    public class UIItemsUsed : MonoBehaviour
    {
        [SerializeField] private List<Ammo> _weaponsAmmo;
        [SerializeField] private List<Item> _weapons;
        [SerializeField] private List<FirstAidKit> _firstAidKits;

        public int WeaponsAmmoCount => _weaponsAmmo.Count;
        public int WeaponsCount => _weapons.Count;
        public int FirstAidKitsCount => _firstAidKits.Count;

        public Ammo GetWeaponAmmoByIndex(int index)
        {
            return _weaponsAmmo[index];
        }

        public Item GetWeaponByIndex(int index)
        {
            return _weapons[index];
        }

        public FirstAidKit GetFirstAidKitByIndex(int index)
        {
            return _firstAidKits[index];
        }

        public FirstAidKit GetFirstAidKitByType(string type)
        {
            foreach (FirstAidKit firstAidKit in _firstAidKits)
            {
                if(firstAidKit.Type == type)
                {
                    return firstAidKit;
                }
            }

            return null;
        }
    }
}