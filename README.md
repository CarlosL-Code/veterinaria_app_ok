Sistema de Gestión para Clínica Veterinaria
Este repositorio contiene un sistema completo para la gestión de una clínica veterinaria, compuesto por un API RESTful y una aplicación cliente de escritorio. El objetivo principal es ofrecer una solución integral para la administración de atenciones, pacientes (mascotas), servicios y categorías.

Tecnologías Utilizadas
Lenguaje: C#

Framework: ASP.NET Core

Gestión de Base de Datos: Entity Framework Core

Base de Datos: SQL Server

Documentación de API: Swashbuckle (Swagger UI)

Entorno de Desarrollo: Visual Studio

Características Principales
API RESTful: Un backend robusto que expone endpoints para realizar operaciones CRUD (Crear, Leer, Actualizar, Borrar).

Gestión de Mascotas: Registro y administración de los datos e historiales de los pacientes.

Control de Atenciones: Registro de consultas, tratamientos y atenciones médicas.

Catálogo de Servicios: Administración de los servicios y productos ofrecidos por la clínica, organizados por categorías.

Documentación Interactiva: Uso de Swagger UI para facilitar la prueba de los endpoints y comprender la estructura de la API.

Estructura del Proyecto
El proyecto está organizado en dos soluciones principales:

API_Veterinaria: Contiene la lógica del backend, incluyendo los controladores, servicios y modelos de datos (entidades).

veterinaria_app_ok: Contiene la aplicación de escritorio que consume la API para la interfaz de usuario.

Estructura de la API
Controllers/: Maneja las solicitudes HTTP.

Services/: Contiene la lógica de negocio.

Entities/: Define los modelos de datos que se mapean a las tablas de la base de datos.

Migrations/: Archivos para las migraciones de Entity Framework Core.

Instalación y Configuración
Clona el repositorio:

git clone [URL_DEL_REPOSITORIO]
cd [NOMBRE_DEL_REPOSITORIO]

Configura la cadena de conexión:
En el archivo appsettings.json de la solución API_Veterinaria, actualiza la cadena de conexión a tu instancia de SQL Server.

Ejecuta las migraciones de la base de datos:
Abre la consola del Administrador de paquetes de NuGet en Visual Studio y ejecuta los siguientes comandos para crear la base de datos:

Add-Migration InitialCreate
Update-Database

Ejecuta el proyecto:
Configura la solución API_Veterinaria como proyecto de inicio y ejecútala. Swagger UI se abrirá automáticamente en tu navegador para que puedas explorar la API.

Endpoints de la API
A continuación se listan los endpoints principales disponibles:

GET /api/Atencion

GET /api/Atencion/{id}

POST /api/Atencion

DELETE /api/Atencion/{id}

POST /api/Atencion/update

GET /api/Categorias

GET /api/Categorias/{id}

POST /api/Categorias

DELETE /api/Categorias/{id}

GET /api/Mascotas

GET /api/Mascotas/{id}

POST /api/Mascotas

DELETE /api/Mascotas/{id}

POST /api/Mascotas/update

GET /api/Servicios

GET /api/Servicios/{id}

POST /api/Servicios

DELETE /api/Servicios/{id}

POST /api/Servicios/update
