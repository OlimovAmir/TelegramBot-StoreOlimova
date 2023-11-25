using PRTelegramBot.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace TelegramBot_StoreOlimova
{
    class Config
    {
        [ReplyMenuHandler(true, "Привет", "Салом", "hi", "Салам")]
        public static async Task Excample(ITelegramBotClient botClient, Update update)
        {
            // Получаем имя отправителя
            string senderName = GetFirstName(update.Message.From);

            // Формируем сообщение с именем отправителя
            var message = $"Добро пожаловать, {senderName}";

            // Отправляем сообщение
            var senMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
        }

        // Метод для получения имени отправителя
        private static string GetFirstName(User user)
        {
            return user.FirstName;
        }
    }
}

