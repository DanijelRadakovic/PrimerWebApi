# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS base
WORKDIR /app
 
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .
RUN dotnet restore "PrimerWebApi/PrimerWebApi.csproj" && \
    dotnet build "PrimerWebApi/PrimerWebApi.csproj" -c Release -o /app/build
 
FROM build AS publish
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 3.1.0 && \
    dotnet publish "PrimerWebApi/PrimerWebApi.csproj" -c Release -o /app/publish && \
    dotnet-ef migrations script -p "PrimerWebApi/PrimerWebApi.csproj" -o /app/sql/init.sql

 
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
WORKDIR /app/publish
VOLUME /app/sql
CMD ASPNETCORE_URLS=http://*:$PORT dotnet PrimerWebApi.dll

