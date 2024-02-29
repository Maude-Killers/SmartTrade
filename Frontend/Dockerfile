# Utiliza la imagen base del SDK de .NET para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia csproj y restaura las dependencias
COPY Frontend.csproj .

RUN dotnet restore

# Copia el resto de los archivos del proyecto
COPY . ./
# Compila el proyecto, este paso genera los archivos necesarios en la carpeta /bin
RUN dotnet publish -c Release -o output

# Paso de runtime: Configura NGINX para servir la aplicación Blazor
FROM nginx:alpine AS final

WORKDIR /var/www/web

COPY --from=build /app/output/wwwroot .

COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
