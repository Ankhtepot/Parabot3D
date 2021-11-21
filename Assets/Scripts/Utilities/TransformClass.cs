using System;
using UnityEngine;

namespace Utilities
{
    [Serializable]
    public class TransformClass
    {
        [SerializeField] private Vector3 position;
        [SerializeField] private Quaternion localRotation;
        [SerializeField] private Vector3 localScale;

        public TransformClass(Transform source)
        {
            position = source.position;
            localRotation = source.localRotation;
            localScale = source.localScale;
        }
        
        public void ToTransform(ref Transform transform)
        {
            transform.position = position;
            transform.localRotation = localRotation;
            transform.localScale = localScale;
        }
    }
}