using UnityEngine;

namespace Utilities
{
    [ExecuteInEditMode]
    public class GridSnap : MonoBehaviour
    {
#if UNITY_EDITOR
        private void Update()
        {
            if (!Application.isPlaying)
            {
                var newPosition = transform.position;
                newPosition.x = Mathf.RoundToInt(newPosition.x);
                newPosition.z = Mathf.RoundToInt(newPosition.z);
                transform.position = newPosition;
            }
        }
#endif
    }
}
