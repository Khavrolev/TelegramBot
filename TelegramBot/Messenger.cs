using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot
{
    public class Messenger
    {
        private CommandParser parser;
        private ITelegramBotClient botClient;

        public Messenger(ITelegramBotClient botClient)
        {
            parser = new CommandParser();
            this.botClient = botClient;
        }
        public string CreateTextMessage(Conversation chat)
        {
            var text = "";
            var delimiter = ",";
            text = "Your history: " + string.Join(delimiter, chat.GetTextMessages().ToArray());

            return text;
        }

        public async Task MakeAnswer(Conversation chat)
        {
            var lastmessage = chat.GetLastMessage();

            if (parser.IsMessageCommand(lastmessage))
            {
                await ExecCommand(chat, lastmessage);
            }
            else
            {
                var text = CreateTextMessage(chat);

                await SendText(chat, text);
            }
        }

        private async Task SendText(Conversation chat, string text)
        {
            await botClient.SendTextMessageAsync(
            chatId: chat.GetId(), text: text);
        }

        private async Task ExecCommand(Conversation chat, string text)
        {
            if (parser.IsTextCommand(text))
            {
                IChatTextCommand command = (IChatTextCommand)parser.GetCommand(text);
                await SendText(chat, command.ReturnText());
            }
        }
    }
}
