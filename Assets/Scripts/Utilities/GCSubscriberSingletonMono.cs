using System;
using UnityEngine;

namespace Utilities
{
    public abstract class GCSubscriberSingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }
	
        public virtual void Awake ()
        {
            if (Instance == null) {
                Instance = this as T;
            } else {
                gameObject.SetActive(false);
                Destroy (gameObject);
            }
        }
    }
}