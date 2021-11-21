using UnityEngine;

namespace Extensions
{
    public static class Extensions
    {
        public static void RemoveChildren(this Transform parent)
        {
            foreach (Transform child in parent)
            {
                Object.Destroy(child.gameObject);
            }
        }
    }
}