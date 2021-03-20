using System;
using System.Collections.Generic;

namespace TelegramBot
{
    public class CommandParser
    {
        private List<IChatCommand> Command;

        public CommandParser()
        {
            Command = new List<IChatCommand>();
            AddCommands();
        }

        public void AddCommands()
        {
            Command.Add(new SayHiCommand());
            Command.Add(new AskMeCommand());
            Command.Add(new PoemButtonCommand());
        }

        public IChatCommand GetCommand(string message)
        {
            return Command.Find(x => x.CheckMessage(message));
        }

        public bool IsMessageCommand(string message)
        {
            var command = GetCommand(message);

            return command is not null;
        }

        public bool IsTextCommand(string message)
        {
            var command = GetCommand(message);

            return command is IChatTextCommand;
        }

        public bool IsInlineCommand(string message)
        {
            var command = GetCommand(message);

            return command is IChatInlineCommand;
        }
    }
}
