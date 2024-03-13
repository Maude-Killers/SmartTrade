# Utiliza la imagen base de ASP.NET Core SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY . ./

WORKDIR /app/Backend

RUN dotnet restore Backend.csproj

RUN dotnet publish -c Release -o output

# Genera la imagen final
FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app/Backend

COPY --from=build /app/Backend/output ./

EXPOSE 80

ENTRYPOINT ["dotnet", "Backend.dll"]

# Comando para compilar
# docker build -t backend -f Backend/Dockerfile