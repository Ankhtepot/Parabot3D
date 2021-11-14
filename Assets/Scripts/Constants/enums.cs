using UnityEngine;

namespace Constants {
    public static class enums {
        public enum Colors {
            RED = 0,
            GREEN = 1
        }

        private static Color[] colors = {
            Color.red, // 0
            Color.green // 1
        };

        public static Color GetColor(Colors color) {
            return colors[(int)color];
        }
    }
}
