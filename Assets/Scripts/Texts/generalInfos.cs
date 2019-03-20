using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Texts {
    public static class generalInfos {

        public enum Texts {
            destroyableGrid, // 0
            pressurePlate, // 1
            terminal, // 2
            RespawnPlatform, // 3
            DemoFinish, // 4
            DeathWithoutRespawnPointActivated, // 5
        }

        private static String[] texts = new String[] {
                "This grid seems fragile enough to be destroyed by few, high jumps.", // 0
                "This pressure plate needs some weight on top to do the work.", // 1
                "This is terminal for direct comunication with central AI and to execute special tasks.", // 2
                "This is respawn platform, where you come back to existence if you perish prematurely.", //3
                "You have reached the end of this demo, congratulations!", // 4
                "You haven't activated any respawn point. Level will be restarted." // 5
            };

        public static String getText(Texts text) {

            return texts[(int)text];
        }

    }
}
