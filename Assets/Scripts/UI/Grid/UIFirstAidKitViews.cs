using Health;
using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UI.Grid.Items;
using UnityEngine;

namespace UI.Grid
{
    [RequireComponent(typeof(UIItemsUsed))]
    public class UIFirstAidKitViews : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;

        private List<UIItemButton> _uiItemButtons;
        private UIItemsUsed _itemsUsed;

        private void Awake()
        {
            _itemsUsed = GetComponent<UIItemsUsed>();
        }

        public void Init()
        {
            _uiItemButtons = new List<UIItemButton>();
        }

        public void InitButton(UIItemView itemView, int count, string type)
        {
            UIItemButton itemButton = itemView.GetComponent<UIItemButton>();
            itemButton.Init(count, type);
            _uiItemButtons.Add(itemButton);
            itemButton.Enabled += Subscription;
        }

        private void Subscription(IItemButton itemButton)
        {
            itemButton.Click += OnItemButtonClick;
            itemButton.ButtonDisabled += OnButtonDisabled;
        }

        private void OnItemButtonClick(IItemButton itemButton)
        {
            if (_playerHealth.MaxHealth > _playerHealth.CurrentHealth)
            {
                FirstAidKit firstAidKit = _itemsUsed.GetFirstAidKitByType(itemButton.Type);

                if (firstAidKit != null)
                {
                    if (firstAidKit.CurrentAmount > 0)
                    {
                        _playerHealth.Add(firstAidKit.HealthRestoredCount);
                        firstAidKit.SubtractAmount();
                        itemButton.UIItemVIew.Set(firstAidKit.Icon, firstAidKit.CurrentAmount);
                    }
                }
            }
        }

        private void OnButtonDisabled(IItemButton itemButton)
        {
            itemButton.Click -= OnItemButtonClick;
            itemButton.ButtonDisabled -= OnButtonDisabled;
        }
    }
}