using Health;
using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UI.Grid.Items;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Grid
{
    [RequireComponent(typeof(GridLayoutGroup))]
    [RequireComponent(typeof(UIItemsUsed))]
    [RequireComponent(typeof(UIAmmoViews))]
    public class UIItemsGrid : MonoBehaviour
    {
        [SerializeField] private SlotStatus _slotPrefab;
        [SerializeField] private UIItemView _uiItemPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private PlayerHealth _playerHealth;

        private GridLayoutGroup _gridLayoutGroup;
        private UIItemsUsed _itemsUsed;
        private UIAmmoViews _ammoViews;
        private int _count;
        private List<SlotStatus> _slots;

        private void Awake()
        {
            _gridLayoutGroup = GetComponent<GridLayoutGroup>();
            _itemsUsed = GetComponent<UIItemsUsed>();
            _ammoViews = GetComponent<UIAmmoViews>();
            _count = 20;
            _slots = new List<SlotStatus>();

            for (int i = 0; i < _count; i++)
            {
                SlotStatus slot = Instantiate(_slotPrefab, _container);
                _slots.Add(slot);
            }

            Set();
        }

        private void Start()
        {
            StartCoroutine(SwitchOffGridLayoutGroup());
        }

        public void Set()
        {
            for (int i = 0; i < _itemsUsed.WeaponsCount; i++)
            {
                Item item = _itemsUsed.GetWeaponByIndex(i);
                CreateItem(item.Icon);
            }

            for (int i = 0; i < _itemsUsed.WeaponsAmmoCount; i++)
            {
                Ammo item = _itemsUsed.GetWeaponAmmoByIndex(i);
                CreateItem(item.Icon, out UIItemView uiItemView, item.CurrentAmount);
                _ammoViews.Add(item.Type, uiItemView);
            }

            for (int i = 0; i < _itemsUsed.FirstAidKitsCount; i++)
            {
                FirstAidKit item = _itemsUsed.GetFirstAidKitByIndex(i);
                CreateItem(item.Icon, out UIItemView uiItemView, item.CurrentAmount);
                InitButton(uiItemView, item.HealthRestoredCount, item.Type);
            }
        }

        private void InitButton(UIItemView itemView, int count, string type)
        {
            UIItemButton itemButton = itemView.GetComponent<UIItemButton>();
            itemButton.Init(count, type);
            itemButton.Click += OnItemButtonClick;
            itemButton.ButtonDisabled += OnButtonDisabled;
        }

        private void CreateItem(Sprite icon, int amount = 0)
        {
            SlotStatus slot = _slots.Find(slot => slot.IsBusy == false);
            UIItemView itemView = Instantiate(_uiItemPrefab, slot.transform);
            itemView.Set(icon, amount);
            slot.Set(true);
        }

        private void CreateItem(Sprite icon, out UIItemView uiItemView, int amount = 0)
        {
            SlotStatus slot = _slots.Find(slot => slot.IsBusy == false);
            UIItemView itemView = Instantiate(_uiItemPrefab, slot.transform);
            uiItemView = itemView;
            itemView.Set(icon, amount);
            slot.Set(true);
        }

        private IEnumerator SwitchOffGridLayoutGroup()
        {
            yield return null;
            _gridLayoutGroup.enabled = false;
        }

        private void OnItemButtonClick(IItemButton itemButton)
        {
            if(_playerHealth.MaxHealth > _playerHealth.CurrentHealth)
            {
                FirstAidKit firstAidKit = _itemsUsed.GetFirstAidKitByType(itemButton.Type);

                if(firstAidKit != null)
                {
                    if(firstAidKit.CurrentAmount > 0)
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