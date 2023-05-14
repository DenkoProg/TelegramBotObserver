using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot
{
    class Program

    {
        private static TelegramBotClient _client;
        private static Subject _subject;
        static void Main(string[] args)
        {
            _client = new TelegramBotClient("6133972870:AAEnPqOejsj4kr6WAvUvYQmze2K2CKyoXSo");
            _subject = new Subject();
            _subject.Attach(new ConcreteObserver(_client));

            _client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            _subject.Notify(update);
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

       

        
    }
}

