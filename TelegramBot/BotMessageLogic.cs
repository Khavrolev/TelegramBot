using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Args;

namespace TelegramBot
{
    public class BotMessageLogic
    {
        private Messenger messenger;
        private Dictionary<long, Conversation> chatList;

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            messenger = new Messenger(botClient);
            chatList = new Dictionary<long, Conversation>();
        }

        private Conversation CheckChat(Chat chat)
        {
            if (!chatList.ContainsKey(chat.Id))
            {
                var newchat = new Conversation(chat);

                chatList.Add(chat.Id, newchat);
            }

            return chatList[chat.Id];
        }

        public async Task ResponseText(MessageEventArgs e)
        {
            var chat = CheckChat(e.Message.Chat);

            chat.AddMessage(e.Message);

            await messenger.MakeAnswerOnCommand(chat);
        }

        public async Task ResponseInline(CallbackQueryEventArgs e)
        {
            var chat = CheckChat(e.CallbackQuery.Message.Chat);

            await messenger.MakeAnswerOnInline(chat, e.CallbackQuery.Data, e.CallbackQuery.Id);
        }
    }
}
