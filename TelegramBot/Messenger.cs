using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    public class Messenger
    {
        public string CreateTextMessage(Conversation chat)
        {
            var delimiter = ",";
            var text = "Your history: " + string.Join(delimiter, chat.GetTextMessages().ToArray());

            return text;
        }
    }
}
