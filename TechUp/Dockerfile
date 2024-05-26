FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TechUp/TechUp.csproj", "TechUp/"]
RUN dotnet restore "TechUp/TechUp.csproj"
COPY . .
WORKDIR "/src/TechUp"
RUN dotnet build "TechUp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TechUp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN pwsh /app/playwright.ps1 install --with-deps
ENTRYPOINT ["dotnet", "TechUp.dll"]
