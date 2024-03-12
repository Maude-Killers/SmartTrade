# Utiliza la imagen base de ASP.NET Core SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

# Copia csproj y restaura las dependencias
COPY ["Backend/Backend.csproj", "Backend/"]
COPY ["SmartTrade.Models/SmartTrade.Models.csproj", "SmartTrade.Models/"]

RUN dotnet restore "Backend/Backend.csproj"

# Copia el resto de los archivos y construye la aplicación
COPY . ./

WORKDIR /app/Backend

RUN dotnet publish -c Release -o output

# Genera la imagen final
FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app/Backend

COPY --from=build /app/Backend/output ./

EXPOSE 80

ENTRYPOINT ["dotnet", "Backend.dll"]

# Comando para compilar
# docker build -t backend -f Backend/Dockerfile