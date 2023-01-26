#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6 AS build
WORKDIR /src
COPY ["Rtl.TvMaze.WebApi/Rtl.TvMaze.WebApi.csproj", "Rtl.TvMaze.WebApi/"]
COPY ["Rtl.TvMaze.Infrastructure/Rtl.TvMaze.Infrastructure.csproj", "Rtl.TvMaze.Infrastructure/"]
COPY ["Rtl.TvMaze.Implementation/Rtl.TvMaze.Implementation.csproj", "Rtl.TvMaze.Implementation/"]
COPY ["Rtl.TvMaze.DataAccess/Rtl.TvMaze.DataAccess.csproj", "Rtl.TvMaze.DataAccess/"]
RUN dotnet restore "Rtl.TvMaze.WebApi/Rtl.TvMaze.WebApi.csproj"
COPY . .
WORKDIR "/src/Rtl.TvMaze.WebApi"
RUN dotnet build "Rtl.TvMaze.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rtl.TvMaze.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rtl.TvMaze.WebApi.dll"]