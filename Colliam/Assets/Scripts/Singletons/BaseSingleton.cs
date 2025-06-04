using System;
using UnityEngine;

namespace Singleton
{
    public class BaseSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static readonly object ThreadLock = new object();
        private static T _instance;

        private static bool _isQuitting;

        public static T Instance
        {
            get
            {
                if (_isQuitting)
                {
                    return null;
                }
                
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<T>();

                    lock (ThreadLock)
                    {
                        if (_instance == null)
                        {
                            var newSingleton = new GameObject();
                            newSingleton.name = typeof(T).Name;
                            _instance = newSingleton.AddComponent<T>();
                            DontDestroyOnLoad(newSingleton);
                        }
                    }
                }

                return _instance;
            }
        }

        private void OnDestroy()
        {
            _isQuitting = true;
        }
    }
}