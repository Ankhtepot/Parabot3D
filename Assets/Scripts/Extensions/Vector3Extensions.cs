using UnityEngine;

namespace Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 Zero;

        static Vector3Extensions()
        {
            Zero = Vector3.zero;
        }
    }
}