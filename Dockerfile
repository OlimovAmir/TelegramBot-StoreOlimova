# Используем официальный образ .NET SDK 6.0 для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копируем файлы проекта в контейнер
COPY *.csproj ./
RUN dotnet restore

# Копируем оставшиеся файлы и собираем приложение
COPY . ./
RUN dotnet publish -c Release -o out

# Используем официальный образ .NET Runtime 6.0 для выполнения
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Определяем команду, которая будет выполнена при запуске контейнера
ENTRYPOINT ["dotnet", "TelegramBot-StoreOlimova.dll"]
