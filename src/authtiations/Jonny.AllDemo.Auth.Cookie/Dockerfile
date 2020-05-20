#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/authtiations/Jonny.AllDemo.Auth.Cookie/Jonny.AllDemo.Auth.Cookie.csproj", "src/authtiations/Jonny.AllDemo.Auth.Cookie/"]
RUN dotnet restore "src/authtiations/Jonny.AllDemo.Auth.Cookie/Jonny.AllDemo.Auth.Cookie.csproj"
COPY . .
WORKDIR "/src/src/authtiations/Jonny.AllDemo.Auth.Cookie"
RUN dotnet build "Jonny.AllDemo.Auth.Cookie.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jonny.AllDemo.Auth.Cookie.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jonny.AllDemo.Auth.Cookie.dll"]