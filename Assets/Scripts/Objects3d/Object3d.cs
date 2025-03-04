using UnityEngine;

namespace Objects3d
{
    public class Object3d : MonoBehaviour
    {
        [SerializeField] private ObjectRotate _objectRotate;
        [SerializeField] private string _type;
        [SerializeField] private int _count;

        public string Type => _type;
        public int Count => _count;

        public void Destroy()
        {
            _objectRotate.StopRotate();
            Destroy(transform.gameObject);
        }
    }
}