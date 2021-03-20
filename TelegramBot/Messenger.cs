using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

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

        public async Task MakeAnswerOnCommand(Conversation chat)
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

        public async Task MakeAnswerOnInline(Conversation chat, string data, string Id)
        {
            var text = PoemDictionary.GetPoem(data);

            await SendText(chat, text);
            await botClient.AnswerCallbackQueryAsync(Id);
        }

        private async Task SendText(Conversation chat, string text)
        {
            await botClient.SendTextMessageAsync(
            chatId: chat.GetId(), text: text);
        }

        private async Task SendTextWithKeyBoard(Conversation chat, string text, InlineKeyboardMarkup keyboard)
        {
            await botClient.SendTextMessageAsync(
            chatId: chat.GetId(), text: text, replyMarkup: keyboard);
        }

        private async Task ExecCommand(Conversation chat, string text)
        {
            if (parser.IsTextCommand(text))
            {
                IChatTextCommand command = (IChatTextCommand)parser.GetCommand(text);
                await SendText(chat, command.ReturnText());
            }
            else if (parser.IsInlineCommand(text))
            {
                IChatInlineCommand command = (IChatInlineCommand)parser.GetCommand(text);
                await SendTextWithKeyBoard(chat, command.ReturnText(), command.ReturnKeyboard());
            }
        }
    }
}
