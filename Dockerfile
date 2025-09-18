# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
WORKDIR /source

# Copy project file and restore
COPY WebApp/devops-project.csproj ./WebApp/
RUN dotnet restore WebApp/devops-project.csproj -a $TARGETARCH

# Copy all source code
COPY WebApp/. ./WebApp/

# Publish only the main project
RUN dotnet publish WebApp/devops-project.csproj -c Release -a $TARGETARCH -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 8080
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "devops-project.dll"]
