#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Rtl.TvMaze.Scraper/Rtl.TvMaze.Scraper.csproj", "Rtl.TvMaze.Scraper/"]
RUN dotnet restore "Rtl.TvMaze.Scraper/Rtl.TvMaze.Scraper.csproj"
COPY . .
WORKDIR "/src/Rtl.TvMaze.Scraper"
RUN dotnet build "Rtl.TvMaze.Scraper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rtl.TvMaze.Scraper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rtl.TvMaze.Scraper.dll"]