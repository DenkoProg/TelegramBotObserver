using Telegram.Bot;

public class ConcreteObserver : IObserver
{
    private readonly ITelegramBotClient botClient;
    private List<string> shoppingList = new List<string>();

    public ConcreteObserver(ITelegramBotClient botClient)
    {
        this.botClient = botClient;
    }

    public async void Update(Telegram.Bot.Types.Update update)
    {
        var message = update.Message;
        if (message.Text != null)
        {
            var text = message.Text.ToLower();
            if (text.Contains("hello"))
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Hello, nice to see you!");
            }

            else if (text.StartsWith("add "))
            {
                var item = text.Substring(4);
                shoppingList.Add(item);
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Added {item} to the shopping list.");
            }
            else if (text.StartsWith("delete "))
            {
                var item = text.Substring(7);
                if (shoppingList.Remove(item))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Removed {item} from the shopping list.");
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"{item} is not in the shopping list.");
                }
            }
            else if (text == "list")
            {
                if (shoppingList.Count == 0)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "The shopping list is empty.");
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, string.Join("\n", shoppingList));
                }
            }

        }
    }
}
