# Используем официальный образ для .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

# Устанавливаем Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_20.x | bash - \
    && apt-get install -y nodejs

# Устанавливаем дополнительные инструменты, если необходимо
RUN apt-get update \
    && apt-get install -y \
    build-essential \
    && rm -rf /var/lib/apt/lists/*

# Устанавливаем NPM пакет для подключения к SQL Lite
RUN npm install -g sqlite3@5.1.1 && exit 0

# Устанавливаем .NET CLI инструменты
RUN dotnet tool install --global dotnet-ef

# Устанавливаем переменные окружения для Node.js и .NET
ENV PATH="$PATH:/root/.dotnet/tools"