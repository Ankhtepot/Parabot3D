using UnityEngine;

namespace Utility
{
    public class HVScaler : MonoBehaviour
    {
        [SerializeField] private Transform targetObject;
        [SerializeField] private float xZScale = 1;
        [SerializeField] private float yScale = 1;

#if UNITY_EDITOR
        private void OnValidate() {
            targetObject.localScale = new Vector3(targetObject.localScale.x, yScale, targetObject.localScale.z);
            targetObject.localScale = new Vector3(xZScale, targetObject.localScale.y, xZScale);
        }
#endif
    }
}
