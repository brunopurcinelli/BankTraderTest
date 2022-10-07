FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/BankTrader.WebApi/BankTrader.WebApi.csproj", "src/BankTrader.WebApi/"]
RUN dotnet restore "BankTrader.WebApi/BankTrader.WebApi.csproj"
COPY . .
WORKDIR "/src/BankTrader.WebApi"
RUN dotnet build "BankTrader.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankTrader.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankTrader.WebApi.dll"]