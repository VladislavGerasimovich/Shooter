using UnityEngine;

namespace UI.Grid.Items
{
    [CreateAssetMenu(fileName = "New ItemData", menuName = "Item", order = 51)]
    public class Item : ScriptableObject
    {
        [SerializeField] protected Sprite _image;

        public Sprite Icon => _image;
    }
}