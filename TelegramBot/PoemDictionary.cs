using System;

namespace TelegramBot
{
    public static class PoemDictionary
    {
        public static string GetPoem(string data)
        {
            var text = "";
            switch (data)
            {
                case "pushkin":
                    text = @"Я помню чудное мгновенье:
                                    Передо мной явилась ты,
                                    Как мимолетное виденье,
                                    Как гений чистой красоты.";
                    break;
                case "esenin":
                    text = @"Не каждый умеет петь,
                                Не каждому дано яблоком
                                Падать к чужим ногам.";
                    break;
                default:
                    break;
            }

            return text;
        }
    }
}
