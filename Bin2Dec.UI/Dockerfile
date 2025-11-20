# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM debian:stable-slim
# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the .csproj files from the root level (Bin2Dec.Shared and Bin2Dec.UI)
COPY ["Bin2Dec.UI/Bin2Dec.UI.csproj", "Bin2Dec.UI/"]
COPY ["Bin2Dec.Shared/Bin2Dec.Shared.csproj", "Bin2Dec.Shared/"]

# Restore dependencies
RUN dotnet restore "./Bin2Dec.UI/Bin2Dec.UI.csproj"

# Copy the rest of the code into the container
COPY . .

WORKDIR "/src/Bin2Dec.UI"

# Build the project
RUN dotnet build "./Bin2Dec.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Bin2Dec.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bin2Dec.UI.dll"]
