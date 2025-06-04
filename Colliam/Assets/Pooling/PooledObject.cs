using System;
using System.Collections;
using System.Collections.Generic;
using pooling;
using Unity.VisualScripting;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public int initialPoolSize;

    public event Action<PooledObject> OnReturnToPool;

    public T Get<T>() where T : PooledObject
    {
        var pool = Pool.GetPool(this);
        var pooledObj = pool.Get<T>();
        return pooledObj;
    }

    private void OnDisable()
    {
        OnReturnToPool?.Invoke(this);
    }
}
