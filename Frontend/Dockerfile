# Utiliza la imagen base del SDK de .NET para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Establece el argumento de versión para Node.js
ARG NODE_VERSION=20.x

# Instala Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_$NODE_VERSION | bash - \
    && apt-get install -y nodejs

WORKDIR /app

# Copia csproj y restaura las dependencias
COPY ["Frontend/Frontend.csproj", "Frontend/"]
COPY ["SmartTrade.Models/SmartTrade.Models.csproj", "SmartTrade.Models/"]

RUN dotnet restore "Frontend/Frontend.csproj"

# Copia el resto de los archivos del proyecto
COPY . ./

WORKDIR /app/Frontend

RUN npm install --no-cache && npm run build:css

RUN cp wwwroot/appsettings.Docker.json wwwroot/appsettings.json

# Compila el proyecto, este paso genera los archivos necesarios en la carpeta /bin
RUN dotnet publish -c Release -o output

# Paso de runtime: Configura NGINX para servir la aplicación Blazor
FROM nginx:alpine AS final

WORKDIR /var/www/web

COPY --from=build /app/Frontend/output/wwwroot .

COPY Frontend/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

# Comando para compilar
# docker build -t frontend -f Frontend/Dockerfile