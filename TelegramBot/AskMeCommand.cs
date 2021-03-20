using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    public class AskMeCommand : AbstractCommand, IChatTextCommand
    {
        public AskMeCommand()
        {
            CommandText = "/askme";
        }

        public string ReturnText()
        {
            return "Как дела?";
        }
    }
}
