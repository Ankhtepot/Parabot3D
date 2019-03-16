using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Texts {
    public static class Labels {

        public enum Texts {
            operate, // 0
            exit, // 1
            messages, // 2
            test, // 3
            Open, // 4
            Close // 5
        }

        private static String[] texts = new String[] {
                 "Actions", // 0
                 "Exit", // 1
                 "Messages", // 2
                 "Test", // 3
                 "Open", // 4
                 "Close"
                };

        public static String getText(Texts text) {
            return texts[(int)text];
        }

    }
}
