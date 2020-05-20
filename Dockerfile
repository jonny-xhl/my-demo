# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
# WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/Jonny.AllDemo.Api/*.csproj ./src/
RUN dotnet restore

# copy everything else and build app
COPY src/Jonny.AllDemo.Api/. ./src/
WORKDIR /src/Jonny.AllDemo.Api
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Jonny.AllDemo.Api.dll"]