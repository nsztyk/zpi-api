FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ./src ./src

RUN dotnet restore "./src/ZPI/ZPI.csproj"
RUN dotnet build "./src/ZPI/ZPI.csproj" -c Release -o /app/build

FROM build AS publish
ARG APP_VERSION
RUN dotnet publish "./src/ZPI/ZPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "ZPI.dll"]