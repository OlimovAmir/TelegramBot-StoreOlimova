
using PRTelegramBot.Core;
using System.Data;

const string EXIT_COMMAND = "exit";

// конфигурация бота
var telegram = new PRBot(option =>
{
    option.Token = "6351669134:AAEZN4E-ctWoh8Si8aEzF28sRB9HCa63AJ4";
    option.ClearUpdatesOnStart = true;
    option.WhiteListUsers = new List<long>() { };
    option.Admins = new List<long>() { };
    option.BotId = 0;
});

// команда запуск бота
await telegram.Start();

telegram.OnLogCommon += Telegram_OnLogCommon;
telegram.OnLogError += Telegram_OnLogError;

void Telegram_OnLogError(Exception err, long? id)
{
    Console.ForegroundColor = ConsoleColor.Red;
    string errorMsg = $"{DateTime.Now}:{err}";
    Console.WriteLine(errorMsg);
    Console.ResetColor();
}


void Telegram_OnLogCommon(string msg, PRBot.TelegramEvents typeEnent, ConsoleColor color)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    string message = $"{DateTime.Now}:{msg}";
    Console.WriteLine(message);
    Console.ResetColor();
}


// чтобы программа не закрылась
while (true)
{
    var result = Console.ReadLine();
    if (result.ToLower() == EXIT_COMMAND)
    {
        Environment.Exit(0);
    }
}