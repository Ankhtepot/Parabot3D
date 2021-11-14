using System.Collections.Generic;

namespace Texts
{
    public static class Labels
    {
        public enum ELabel
        {
            None = 0,
            Operate, // 0
            Exit, // 1
            Messages, // 2
            Test, // 3
            Open, // 4
            Close, // 5  
            L1_TerminalRoomTerminal_OpenEntryRoomDoor // 6
        }

        private static readonly Dictionary<ELabel, string> texts = new Dictionary<ELabel, string>()
        {
            { ELabel.None, "THIS LABEL IS NOT LISTED" },
            { ELabel.Messages, "Messages" },
            { ELabel.Test, "Test" },
            { ELabel.Open, "Open" },
            { ELabel.Close, "Close" },
            { ELabel.Operate, "Operate"},
            { ELabel.Exit, "Exit" },
            { ELabel.L1_TerminalRoomTerminal_OpenEntryRoomDoor, "Main room east door controller."}
        };

        public static string GetLabel(ELabel label)
        {
            return texts.TryGetValue(label, out var result) 
                ? result 
                : texts[ELabel.None];
        }
    }
}