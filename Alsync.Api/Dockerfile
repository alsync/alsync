#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./Alsync.Api.csproj", "./"]
COPY ["../Alsync.Domain.Repositories/Alsync.Domain.Repositories.csproj", "../Alsync.Domain.Repositories/"]
COPY ["Alsync.Domain/Alsync.Domain.csproj", "Alsync.Domain/"]
COPY ["Alsync.Infrastructure/Alsync.Infrastructure.csproj", "Alsync.Infrastructure/"]
COPY ["Alsync.Infrastructure.Caching/Alsync.Infrastructure.Caching.csproj", "Alsync.Infrastructure.Caching/"]
COPY ["Alsync.Infrastructure.DependencyInjection/Alsync.Infrastructure.DependencyInjection.csproj", "Alsync.Infrastructure.DependencyInjection/"]
COPY ["Alsync.Infrastructure.Caching.Redis/Alsync.Infrastructure.Caching.Redis.csproj", "Alsync.Infrastructure.Caching.Redis/"]
COPY ["Alsync.IApplication/Alsync.IApplication.csproj", "Alsync.IApplication/"]
COPY ["Alsync.Application/Alsync.Application.csproj", "Alsync.Application/"]
COPY ["Alsync.Api.V1/Alsync.Api.V1.csproj", "Alsync.Api.V1/"]
COPY ["Alsync.Infrastructure.Mvc/Alsync.Infrastructure.Mvc.csproj", "Alsync.Infrastructure.Mvc/"]
COPY ["Alsync.Api.V2/Alsync.Api.V2.csproj", "Alsync.Api.V2/"]
RUN dotnet restore "./Alsync.Api.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Alsync.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alsync.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alsync.Api.dll"]