using System.Collections.Generic;

namespace Texts
{
    public static class Labels
    {
        public enum ELabel
        {
            None = 0,
            Back = 13,
            Close = 1,
            DoorsLocation = 14,
            Exit = 2,
            From = 3,
            FromLeader = 4,
            L1_MainHub = 16,
            L1_TerminalRoomTerminal_OpenEntryRoomDoor = 5,
            Mails = 15,
            Message = 6,
            Messages = 7,
            Operations = 8,
            Open = 9,
            Test = 10,
            To = 11,
            ToAll = 12,
        }

        private static readonly Dictionary<ELabel, string> texts = new Dictionary<ELabel, string>()
        {
            { ELabel.None, "THIS LABEL IS NOT LISTED" },
            { ELabel.Back, "Back" },
            { ELabel.Close, "Close" },
            { ELabel.DoorsLocation, "Operate doors in:" },
            { ELabel.Exit, "Exit" },
            { ELabel.From, "From:" },
            { ELabel.FromLeader, "Your Superior Leader!" },
            { ELabel.L1_MainHub , "Main Hub"},
            { ELabel.L1_TerminalRoomTerminal_OpenEntryRoomDoor, "Main room east door controller." },
            { ELabel.Mails, "Mails" },
            { ELabel.Message, "Message:" },
            { ELabel.Messages, "Messages" },
            { ELabel.Operations, "Operations" },
            { ELabel.Open, "Open" },
            { ELabel.Test, "Test" },
            { ELabel.To, "To:" },
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