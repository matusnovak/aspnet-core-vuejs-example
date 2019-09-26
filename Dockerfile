FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src

# Node + npm
RUN apt-get update -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash - && apt-get install -yq nodejs

# Copy cspoj files only and restore
COPY src/Example/Example.csproj Example/
COPY src/Example.Api/Example.Api.csproj Example.Api/
RUN dotnet restore "Example/Example.csproj"

# Copy project files and build
COPY ./src/Example ./Example/
COPY ./src/Example.Api ./Example.Api/
WORKDIR /src/Example
RUN ls /src/Example
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Create a published version
FROM build AS publish
RUN ls /src/Example/Client
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Finally run the image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
