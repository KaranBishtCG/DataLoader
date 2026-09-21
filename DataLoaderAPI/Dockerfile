# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["DataLoaderAPI.csproj", "./"]

RUN dotnet restore "DataLoaderAPI.csproj"

COPY . .

RUN dotnet publish "DataLoaderAPI.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 10000

ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "DataLoaderAPI.dll"]