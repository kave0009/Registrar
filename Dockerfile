FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Registrar.csproj", "./"]
RUN dotnet restore "Registrar.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Registrar.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Registrar.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Copy the SSL certificate into the container
COPY DigiCertGlobalRootCA.crt.pem /app/

ENTRYPOINT ["dotnet", "Registrar.dll"]
