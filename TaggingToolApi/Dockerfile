﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TaggingToolApi/TaggingToolApi.csproj", "TaggingToolApi/"]
RUN dotnet restore "TaggingToolApi/TaggingToolApi.csproj"
COPY . .
WORKDIR "/src/TaggingToolApi"
RUN dotnet build "TaggingToolApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaggingToolApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaggingToolApi.dll"]
