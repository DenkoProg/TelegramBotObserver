using System.Collections.Generic;
using Telegram.Bot.Types;

public class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(Update update)
    {
        foreach (var observer in observers)
        {
            observer.Update(update);
        }
    }
}
