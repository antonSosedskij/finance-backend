FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["finance-backend/finance-backend.csproj", "finance-backend/"]
RUN dotnet restore "finance-backend/finance-backend.csproj"
COPY . .
WORKDIR "/src/finance-backend"
RUN dotnet build "finance-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "finance-backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "finance-backend.dll"]
