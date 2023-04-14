using UnityEngine;
using Zenject;

namespace Services.Pools
{
    public class MonoObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        [SerializeField] private Transform _container;

        [SerializeField] private bool _isUsedDiContainer;

        [SerializeField] private int _startCount;

        private ObjectPool _objectPool;


        public ObjectPool GetObjectPool(DiContainer diContainer)
        {
            return _objectPool ??= new ObjectPool(_prefab, _startCount, _container,
                _isUsedDiContainer ? diContainer : null);
        }
    }
}