# Utiliza la imagen base de ASP.NET Core SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

# Copia csproj y restaura las dependencias
COPY Backend.csproj ./

RUN dotnet restore

# Copia el resto de los archivos y construye la aplicación
COPY . ./

RUN dotnet publish -c Release -o output

# Genera la imagen final
FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build /app/output ./

EXPOSE 80

ENTRYPOINT ["dotnet", "Backend.dll"]