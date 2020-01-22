FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ProjectHub.Api/ProjectHub.Api.csproj", "ProjectHub.Api/"]
RUN dotnet restore "ProjectHub.Api/ProjectHub.Api.csproj"
COPY . .
WORKDIR "/src/ProjectHub.Api"
RUN dotnet build "ProjectHub.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectHub.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectHub.Api.dll"]