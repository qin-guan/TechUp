FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TechUp.CommandLine/TechUp.CommandLine.csproj", "TechUp.CommandLine/"]
RUN dotnet restore "TechUp.CommandLine/TechUp.CommandLine.csproj"
COPY . .
WORKDIR "/src/TechUp.CommandLine"
RUN dotnet build "TechUp.CommandLine.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TechUp.CommandLine.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechUp.CommandLine.dll"]
