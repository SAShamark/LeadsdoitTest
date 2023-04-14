using Services.Pools;
using UnityEngine;

namespace Entities.Destroyables
{
    public class PoolDestroyable : MonoBehaviour, IDestroyable
    {
        private ObjectPool _objectPool;


        public void Init(ObjectPool objectPool)
        {
            _objectPool = objectPool;
        }

        public virtual void DestroyObject()
        {
            _objectPool.TurnOffObject(gameObject);
        }
    }
}