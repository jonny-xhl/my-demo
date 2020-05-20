#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Jonny.AllDemo.BlazorAppTest/Jonny.AllDemo.BlazorAppTest.csproj", "Jonny.AllDemo.BlazorAppTest/"]
RUN dotnet restore "Jonny.AllDemo.BlazorAppTest/Jonny.AllDemo.BlazorAppTest.csproj"
COPY . .
WORKDIR "/src/Jonny.AllDemo.BlazorAppTest"
RUN dotnet build "Jonny.AllDemo.BlazorAppTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jonny.AllDemo.BlazorAppTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jonny.AllDemo.BlazorAppTest.dll"]