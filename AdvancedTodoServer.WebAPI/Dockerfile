FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

RUN mkdir -p /app/wwwroot && chmod -R 777 /app/wwwroot

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AdvancedTodoServer.WebAPI/AdvancedTodoServer.WebAPI.csproj", "AdvancedTodoServer.WebAPI/"]
RUN dotnet restore "./AdvancedTodoServer.WebAPI/AdvancedTodoServer.WebAPI.csproj"
COPY . .
WORKDIR "/src/AdvancedTodoServer.WebAPI"
RUN dotnet build "./AdvancedTodoServer.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AdvancedTodoServer.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN mkdir -p /app/wwwroot && chmod -R 777 /app/wwwroot

ENTRYPOINT ["dotnet", "AdvancedTodoServer.WebAPI.dll"]