using System.Collections.Generic;

namespace Texts
{
    public static class Labels
    {
        public enum ELabel
        {
            None = 0,
            Close,
            Exit,
            FromLeader,
            L1_TerminalRoomTerminal_OpenEntryRoomDoor,
            Messages,
            Operations,
            Open,
            Test,
            ToAll,
        }

        private static readonly Dictionary<ELabel, string> texts = new Dictionary<ELabel, string>()
        {
            { ELabel.None, "THIS LABEL IS NOT LISTED" },
            { ELabel.Close, "Close" },
            { ELabel.Exit, "Exit" },
            { ELabel.FromLeader, "Your Superior Leader!" },
            { ELabel.L1_TerminalRoomTerminal_OpenEntryRoomDoor, "Main room east door controller."},
            { ELabel.Messages, "Messages" },
            { ELabel.Operations, "Operations"},
            { ELabel.Open, "Open" },
            { ELabel.Test, "Test" },
            { ELabel.ToAll, "To EVERYONE!" }
        };

        public static string GetLabel(ELabel label)
        {
            return texts.TryGetValue(label, out var result) 
                ? result 
                : texts[ELabel.None];
        }
    }
}