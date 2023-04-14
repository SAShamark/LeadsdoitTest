using System.Collections.Generic;
using Entities;
using UnityEngine;
using Zenject;

namespace Services.Pools
{
    public class ObjectPool
    {
        private readonly DiContainer _diContainer;
        private List<GameObject> _includedPool;
        private GameObject Prefab { get; }
        private Transform Container { get; }
        private List<GameObject> ExcludedPool { get; set; }

        private List<GameObject> IncludedPool
        {
            get => _includedPool;
            set => _includedPool = value;
        }


        public ObjectPool(GameObject prefab, int count, Transform container, DiContainer diContainer)
        {
            _diContainer = diContainer;
            Prefab = prefab;
            Container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            ExcludedPool = new List<GameObject>();
            IncludedPool = new List<GameObject>();
            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private GameObject CreateObject(bool isActiveByDefault = false)
        {
            GameObject createObject = _diContainer != null
                ? _diContainer.InstantiatePrefab(Prefab, Container)
                : Object.Instantiate(Prefab, Container);


            createObject.gameObject.SetActive(isActiveByDefault);
            var destroyables = createObject.gameObject.GetComponents<PoolDestroyable>();
            if (destroyables is { Length: > 0 })
            {
                foreach (PoolDestroyable poolDestroyable in destroyables)
                {
                    poolDestroyable.Init(this);
                }
            }
            else
            {
                createObject.AddComponent<PoolDestroyable>().Init(this);
            }


            if (isActiveByDefault)
            {
                IncludedPool.Add(createObject);
            }
            else
            {
                ExcludedPool.Add(createObject);
            }

            return createObject;
        }

        private bool HasFreeElement(out GameObject element)
        {
            if (ExcludedPool.Count > 0)
            {
                GameObject mono = ExcludedPool[0];
                element = mono;
                mono.gameObject.SetActive(true);
                IncludedPool.Add(mono);
                ExcludedPool.Remove(mono);
                return true;
            }

            element = null;
            return element;
        }

        public void TurnOffObject(GameObject obj)
        {
            obj.gameObject.SetActive(false);
            IncludedPool.Remove(obj);
            ExcludedPool.Add(obj);
        }

        public GameObject GetFreeElement()
        {
            return HasFreeElement(out GameObject element) ? element : CreateObject(true);
        }

    }
}