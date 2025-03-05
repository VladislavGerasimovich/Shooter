using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Grid
{
    public class UIAmmoViews : MonoBehaviour
    {
        public Dictionary<string, UIItemView> _uiItemViewsByType;

        private void Awake()
        {
            _uiItemViewsByType = new Dictionary<string, UIItemView>();
        }

        public void Add(string type, UIItemView uiItemView)
        {
            _uiItemViewsByType.Add(type, uiItemView);
        }

        public UIItemView Get(string type)
        {
            foreach (KeyValuePair<string, UIItemView> itemViewByType in _uiItemViewsByType)
            {
                if(itemViewByType.Key == type)
                {
                    return itemViewByType.Value;
                }
            }

            return null;
        }
    }
}