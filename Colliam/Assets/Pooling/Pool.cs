using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace pooling
{
    public class Pool : MonoBehaviour
    {
        private static Dictionary<PooledObject, Pool> _pools = new();
        private Queue<PooledObject> _objectQueue = new Queue<PooledObject>();
        private PooledObject _pooledObjectPrefab;

        public void SetPrefab(PooledObject obj)
        {
            _pooledObjectPrefab = obj;
        }

        public static Pool GetPool(PooledObject obj)
        {
            if (_pools.TryGetValue(obj, out var pool))
            {
                return pool;
            }

            GameObject newPool = new GameObject(obj.name + " Pool");
            Pool poolRef = newPool.AddComponent<Pool>();
            poolRef.SetPrefab(obj);
            _pools.Add(obj,poolRef);
            return poolRef;
        }

        public T Get<T>() where T: PooledObject
        {
       
            
            if (_objectQueue.Count == 0)
            {
                GrowPool();
            }

            return _objectQueue.Dequeue() as T;
        }

        private void GrowPool()
        {
            for (int i = 0; i < _pooledObjectPrefab.initialPoolSize; i++)
            {
                var newPooledObj = Instantiate(_pooledObjectPrefab);
                newPooledObj.OnReturnToPool += ReturnToQueue;
                newPooledObj.gameObject.SetActive(false);
            }
        }

        private void ReturnToQueue(PooledObject pooledObj)
        {
            _objectQueue.Enqueue(pooledObj);
        }
    }
}