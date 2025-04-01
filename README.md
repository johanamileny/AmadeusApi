# AmadeusApi - Sistema de Recomendación de Viajes

AmadeusApi es una API web RESTful construida con ASP.NET Core que proporciona recomendaciones de destinos turísticos basadas en las preferencias del usuario. El sistema permite a los usuarios responder una serie de preguntas y, según sus respuestas, recomienda ciudades destino que coinciden con sus preferencias.

**Características**

•	Gestión de usuarios
•	Administración de preguntas y respuestas
•	Datos de ciudades y destinos
•	Sistema de cuestionarios
•	Coincidencia de destinos basada en preferencias del usuario

**Requisitos previos**

•	SDK de .NET 9.0
•	PostgreSQL (versión 12 o superior)
•	Un IDE como Visual Studio o Visual Studio Code

*Primeros pasos*

1. Clonar el repositorio
git clone <url-repositorio>
cd AmadeusApi

2. Configurar la conexión a la base de datos
Crea o actualiza el archivo appsettings.Development.json con tu cadena de conexión a PostgreSQL:
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=amadeusdb;Username=tuusuario;Password=tucontraseña"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}

3. Ejecutar migraciones de base de datos
dotnet ef database update

4. Cargar datos iniciales
El proyecto incluye un script SQL para cargar datos iniciales. Ejecuta el script BulkInsertSQL.sql en tu base de datos para poblar los datos de preguntas, opciones y ciudades.

5. Ejecutar la aplicación
dotnet run
La API se iniciará en http://localhost:5222 (HTTP) o https://localhost:7096 (HTTPS) por defecto. Puedes acceder a la documentación de Swagger en http://localhost:5222/swagger.

 # Endpoints de la API

La API proporciona los siguientes endpoints principales:

**Usuarios**
•	GET /api/user - Obtener todos los usuarios
•	GET /api/user/{id} - Obtener usuario por ID
•	POST /api/user - Crear un nuevo usuario
•	PUT /api/user/{id} - Actualizar un usuario
•	DELETE /api/user/{id} - Eliminar un usuario

**Preguntas**
•	GET /api/question - Obtener todas las preguntas
•	GET /api/question/{id} - Obtener pregunta por ID
•	POST /api/question - Crear una nueva pregunta
•	PUT /api/question/{id} - Actualizar una pregunta
•	DELETE /api/question/{id} - Eliminar una pregunta

**Opciones de Pregunta**
•	GET /api/questionoption - Obtener todas las opciones de pregunta
•	GET /api/questionoption/{id} - Obtener opción de pregunta por ID
•	GET /api/questionoption/ByQuestion/{questionId} - Obtener opciones para una pregunta específica
•   GET /api/destinations?hash=${hash} - Buscar la combinacion los destionos de acuerdo a las resppuestas
•	POST /api/questionoption - Crear una nueva opción de pregunta
•	PUT /api/questionoption/{id} - Actualizar una opción de pregunta
•	DELETE /api/questionoption/{id} - Eliminar una opción de pregunta

**Respuestas**
•	GET /api/answer - Obtener todas las respuestas
•	GET /api/answer/{id} - Obtener respuesta por ID
•	POST /api/answer - Crear una nueva respuesta
•	PUT /api/answer/{id} - Actualizar una respuesta
•	DELETE /api/answer/{id} - Eliminar una respuesta

**Ciudades**
•	GET /api/cities - Obtener todas las ciudades
•	GET /api/cities/{id} - Obtener ciudad por ID
•	GET /api/cities/name/{name} - Obtener ciudad por nombre
•	POST /api/cities/new - Crear una nueva ciudad
•	PUT /api/cities/update/{id} - Actualizar una ciudad
•	DELETE /api/cities/remove/{id} - Eliminar una ciudad

**Destinos**
•	GET /api/destinations - Obtener todos los destinos
•	GET /api/destinations/{id} - Obtener destino por ID
•	POST /api/destinations/new - Crear un nuevo destino
•	PUT /api/destinations/update/{id} - Actualizar un destino
•	DELETE /api/destinations/remove/{id} - Eliminar un destino

 *Estructura del Proyecto*
•	Controllers - Endpoints de la API
•	Models - Modelos de datos
•	Repositories - Capa de acceso a datos
•	Services - Lógica de negocio
•	Data - Contexto de base de datos
•	Utils - Clases utilitarias
•	Migrations - Migraciones de base de datos
•	Resources - Recursos estáticos (imágenes)

*Integración con Frontend*
La API incluye configuración CORS para permitir solicitudes desde un frontend ejecutándose en http://localhost:5173. Para conectar una aplicación frontend, asegúrate de que se ejecute en esta dirección o actualiza la política CORS en Program.cs.
Licencia
Este proyecto está licenciado bajo la Licencia MIT - consulta el archivo LICENSE para más detalles.

