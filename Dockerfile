FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_ENVIRONMENT=Development

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["IALClient.csproj", "./"]
RUN dotnet restore "IALClient.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "IALClient.csproj" -c $configuration -o /app/build

RUN dotnet dev-certs https --trust

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "IALClient.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IALClient.dll"]
