﻿FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GSCS Cameras Server/GSCS Cameras Server.csproj", "GSCS Cameras Server/"]
RUN dotnet restore "GSCS Cameras Server/GSCS Cameras Server.csproj"
COPY . .
WORKDIR "/src/GSCS Cameras Server"
RUN dotnet build "GSCS Cameras Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GSCS Cameras Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GSCS Cameras Server.dll"]
