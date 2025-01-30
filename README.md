# RealEstateAPI

**RealEstateAPI** es una API de prueba desarrollada en .NET 8 que proporciona funcionalidades relacionadas con el sector inmobiliario. Este proyecto está estructurado siguiendo las mejores prácticas de arquitectura de software, facilitando su mantenimiento y escalabilidad.

## Estructura del Proyecto

El proyecto está organizado en los siguientes módulos:

- **BackendAPIRest.Api**: Contiene los controladores y la configuración de la API.
- **BackendAPIRest.Application**: Incluye la lógica de negocio y las interfaces de los servicios.
- **BackendAPIRest.Domain**: Define las entidades y las reglas de negocio fundamentales.
- **BackendAPIRest.Infrastructure**: Gestiona la comunicación con la base de datos y otras implementaciones de servicios.

## Requisitos Previos

Antes de comenzar, asegúrate de tener instalados los siguientes componentes:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MongoDB](https://www.mongodb.com/docs/manual/installation/)

## Configuración

1. **Clonar el repositorio**:

   ```bash
   git clone https://github.com/serosc95/RealEstateAPI.git BackendAPIRest
   cd BackendAPIRest
   ```

2. **Restaurar las dependencias**:

   ```bash
   dotnet restore
   ```

3. **Actualizar la cadena de conexión**:

   En el archivo `appsettings.json` dentro del proyecto `BackendAPIRest.Api`, actualiza la cadena de conexión a la base de datos según tu configuración.

## Ejecución

Para iniciar la aplicación, ejecuta el siguiente comando en la raíz del proyecto:

```bash
   dotnet run --project BackendAPIRest.Api
```

La API estará disponible en `https://localhost:5044`

## Uso

Puedes interactuar con la API utilizando herramientas como [Postman](https://www.postman.com/) o [Swagger UI](https://swagger.io/tools/swagger-ui/).

Para acceder a Swagger UI, navega a `https://localhost:5044/swagger` después de iniciar la aplicación.
