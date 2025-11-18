# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar solo archivos de solución y csproj para aprovechar la cache de Docker
COPY SRT.sln ./
COPY SRT/*.csproj ./SRT/
COPY SRT.Domain/*.csproj ./SRT.Domain/
COPY SRT.Domain.Utils/*.csproj ./SRT.Domain.Utils/
COPY SRT.Domain.Models/*.csproj ./SRT.Domain.Models/
COPY SRT.Domain.Entities/*.csproj ./SRT.Domain.Entities/
COPY SRT.Infrastructure/*.csproj ./SRT.Infrastructure/

# Restaurar dependencias
RUN dotnet restore SRT/SRT.csproj

# Copiar el resto del código
COPY . .

# Publicar en modo Release
RUN dotnet publish SRT/SRT.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Render suele exponer el puerto 10000 internamente, pero la app escucha en 8080 por convención de contenedor
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Copiar artefactos publicados
COPY --from=build /app/publish .

# Comando de arranque
ENTRYPOINT ["dotnet", "SRT.dll"]