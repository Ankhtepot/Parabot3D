using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Texts {
    public static class generalInfos {

        public enum Texts {
            destroyableGrid,
            pressurePlate,
            terminal
        }

        private static String[] texts = new String[] {
                "This grid seems fragile enough to be destroyed by few, high jumps.", // 0
                "This pressure plate needs some weight on top to do the work.", // 1
                "This is terminal for direct comunication with central AI and to execute special tasks.", // 2
            };

        public static String getText(Texts text) {

            return texts[(int)text];
        }

    }
}
