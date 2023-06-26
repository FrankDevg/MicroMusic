#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroBroker.User.Api/MicroBroker.User.Api.csproj", "MicroBroker.User.Api/"]
COPY ["MicroBroker.Infra.IoC/MicroBroker.Infra.IoC.csproj", "MicroBroker.Infra.IoC/"]
COPY ["MicroBroker.Album.Application/MicroBroker.Album.Application.csproj", "MicroBroker.Album.Application/"]
COPY ["MicroBroker.Album.Infraestructure/MicroBroker.Album.Infraestructure.csproj", "MicroBroker.Album.Infraestructure/"]
COPY ["MicroBroker.Album.Domain/MicroBroker.Album.Domain.csproj", "MicroBroker.Album.Domain/"]
COPY ["MicroBroker.Domain.Core/MicroBroker.Domain.Core.csproj", "MicroBroker.Domain.Core/"]
COPY ["MicroBroker.Artist.Application/MicroBroker.Artist.Application.csproj", "MicroBroker.Artist.Application/"]
COPY ["MicroBroker.Artist.Infraestructure/MicroBroker.Artist.Infraestructure.csproj", "MicroBroker.Artist.Infraestructure/"]
COPY ["MicroBroker.Artist.Domain/MicroBroker.Artist.Domain.csproj", "MicroBroker.Artist.Domain/"]
COPY ["MicroBroker.Catalog.Application/MicroBroker.Catalog.Application.csproj", "MicroBroker.Catalog.Application/"]
COPY ["MicroBroker.Catalog.Infraestructure/MicroBroker.Catalog.Infraestructure.csproj", "MicroBroker.Catalog.Infraestructure/"]
COPY ["MicroBroker.Catalog.Domain/MicroBroker.Catalog.Domain.csproj", "MicroBroker.Catalog.Domain/"]
COPY ["MicroBroker.Infra.Bus/MicroBroker.Infra.Bus.csproj", "MicroBroker.Infra.Bus/"]
COPY ["MicroBroker.Playlist.Application/MicroBroker.Playlist.Application.csproj", "MicroBroker.Playlist.Application/"]
COPY ["MicroBroker.Playlist.Infraestructure/MicroBroker.Playlist.Infraestructure.csproj", "MicroBroker.Playlist.Infraestructure/"]
COPY ["MicroBroker.Playlist.Domain/MicroBroker.Playlist.Domain.csproj", "MicroBroker.Playlist.Domain/"]
COPY ["MicroBroker.Song.Application/MicroBroker.Song.Application.csproj", "MicroBroker.Song.Application/"]
COPY ["MicroBroker.Song.Infraestructure/MicroBroker.Song.Infraestructure.csproj", "MicroBroker.Song.Infraestructure/"]
COPY ["MicroBroker.Song.Domain/MicroBroker.Song.Domain.csproj", "MicroBroker.Song.Domain/"]
COPY ["MicroBroker.User.Application/MicroBroker.User.Application.csproj", "MicroBroker.User.Application/"]
COPY ["MicroBroker.User.Infraestructure/MicroBroker.User.Infraestructure.csproj", "MicroBroker.User.Infraestructure/"]
COPY ["MicroBroker.User.Domain/MicroBroker.User.Domain.csproj", "MicroBroker.User.Domain/"]
RUN dotnet restore "MicroBroker.User.Api/MicroBroker.User.Api.csproj"
COPY . .
WORKDIR "/src/MicroBroker.User.Api"
RUN dotnet build "MicroBroker.User.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroBroker.User.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroBroker.User.Api.dll"]