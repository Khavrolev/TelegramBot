using System;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public interface IChatInlineCommand
    {
        string ReturnText();
        InlineKeyboardMarkup ReturnKeyboard();
    }
}
