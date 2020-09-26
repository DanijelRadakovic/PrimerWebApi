FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
 
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PrimerWebApi.csproj", "PrimerWebApi/"]
RUN dotnet restore "PrimerWebApi/PrimerWebApi.csproj"
WORKDIR "/src/PrimerWebApi"
COPY . .
RUN dotnet build "PrimerWebApi.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "PrimerWebApi.csproj" -c Release -o /app/publish
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet PrimerWebApi.dll
