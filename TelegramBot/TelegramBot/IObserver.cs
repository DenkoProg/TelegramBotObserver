using Telegram.Bot;

public interface IObserver
{
    void Update(Telegram.Bot.Types.Update update);
}

