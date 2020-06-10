#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/mvc.viewcomponent/Jonny.AdllDemo.Mvc.ViewComponents/Jonny.AdllDemo.Mvc.ViewComponents.csproj", "src/mvc.viewcomponent/Jonny.AdllDemo.Mvc.ViewComponents/"]
RUN dotnet restore "src/mvc.viewcomponent/Jonny.AdllDemo.Mvc.ViewComponents/Jonny.AdllDemo.Mvc.ViewComponents.csproj"
COPY . .
WORKDIR "/src/src/mvc.viewcomponent/Jonny.AdllDemo.Mvc.ViewComponents"
RUN dotnet build "Jonny.AdllDemo.Mvc.ViewComponents.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jonny.AdllDemo.Mvc.ViewComponents.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jonny.AdllDemo.Mvc.ViewComponents.dll"]