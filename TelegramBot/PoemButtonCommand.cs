using System;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class PoemButtonCommand : AbstractCommand, IChatInlineCommand
    {
        public PoemButtonCommand()
        {
            CommandText = "/poembuttons";
        }

        public string ReturnText()
        {
            return "Выбирете поэта";
        }

        public InlineKeyboardMarkup ReturnKeyboard()
        {
            var buttonList = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton
                {
                    Text = "Пушкин",
                    CallbackData = "pushkin"
                },

                new InlineKeyboardButton
                {
                    Text = "Есенин",
                    CallbackData = "esenin"
                }
            };

            var keyboard = new InlineKeyboardMarkup(buttonList);

            return keyboard;
        }
    }
}
