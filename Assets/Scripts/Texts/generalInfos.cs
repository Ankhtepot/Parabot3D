using System;
using System.Collections.Generic;

namespace Texts
{
    public static class generalInfos
    {
        public enum ETexts
        {
            destroyableGrid,
            pressurePlate,
            terminal,
            RespawnPlatform,
            DemoFinish,
            DeathWithoutRespawnPointActivated,
            MailL1T1,
        }

        private static readonly Dictionary<ETexts, string> texts = new Dictionary<ETexts, string>()
        {
            { ETexts.destroyableGrid, "This grid seems fragile enough to be destroyed by few, high jumps." },
            { ETexts.pressurePlate, "This pressure plate needs some weight on top to do the work." },
            { ETexts.terminal, "This is terminal for direct communication with central AI and to execute special tasks." },
            { ETexts.RespawnPlatform, "This is respawn platform, where you come back to existence if you perish prematurely." },
            { ETexts.DemoFinish, "You have reached the end of this demo, congratulations!" },
            { ETexts.DeathWithoutRespawnPointActivated, "You haven't activated any respawn point. Level will be restarted." },
            { ETexts.MailL1T1, "R1D1 escaped! Stop him atr all cost, he must not get out of this prison!" }
        };

        public static string getText(ETexts text)
        {
            if (texts.TryGetValue(text, out var foundText))
            {
                return foundText;
            }

            throw new ArgumentOutOfRangeException($"Text {Enum.GetName(typeof(ETexts), text)} was not implemented.");
        }
    }
}