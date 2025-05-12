# --- Build stage ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiera csproj- och lösningsfiler först (s.k. layer caching)
COPY WebShop/*.csproj WebShop/
COPY WebShopTests/*.csproj WebShopTests/
RUN dotnet restore WebShop/WebShop.csproj

# Kopiera resten av koden och publicera
COPY . .
RUN dotnet publish WebShop/WebShop.csproj -c Release -o /app

# --- Runtime stage ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Startkommandot
ENTRYPOINT ["dotnet", "WebShop.dll"]