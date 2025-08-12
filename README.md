# SRT api

## Estructura del proyecto

```
.
├───Application                         # Capa de aplicación - Proyectos de inicio
│   └───SRT                             # Proyecto de inicio
│       ├───Controllers                 # Controladores del Api
│       │   └───Base                    # Clases base para todos los controladores
│       ├───Properties                  # Propiedades del api Ejemplo: url de la aplicación
│       └───Dependency                  # Inyección de dependencias y configuraciones del proyecto
├───Domain                              # Capa de dominio - Logica de negocio
│   ├───SRT.Domain                      # Abstracción de repositorios e implementación de servicios
│   │   ├───Repositories                # Repositorios - Abstracción
│   │   │   └───Interface               # Interfaces de los repositorios del proyecto
│   │   │       └───Base                # Interfaces base
│   │   └───Services                    # Servicios - Lógica de negocio
│   │       ├───Implementation          # Implementación de servicios
│   │       └───Interface               # Interfaces de servicios
│   ├───SRT.Domain.Entities             # Representación de entidades de base de datos - modelos
│   │   └───Base                        # Clases base de entidades
│   ├───SRT.Domain.Models               # Modelos auxiliares del proyecto
│   │   ├───Dtos                        # Dtos del proyecto
│   │   │   ├───Auth                    # Dtos Autenticación
│   │   │   └───Users                   # Dtos Usuarios
│   │   └───Helpers                     # Dtos auxiliares
│   └───SRT.Domain.Utils                # Utilidades del proyecto
│       └───Extensions                  # Extensiones del proyecto
└───Infraestructure                     # Capa de Infraestructura - Base de datos
    └───SRT.Infraestructure             # Implementación de repositorios, conexión y scripts
        ├───Database                    # Conexión y utilidades de base de datos
        ├───Repositories                # Repositorios
        │   └───Implementation          # Implementación de repositorios
        │       └───Base                # Repositorios base
        └───Scripts                     # Scripts Sql del proyecto
```

## AppSettings

```json5
{
  // Configuración de Loggers
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  // Cadenas de conexión
  "ConnectionStrings": {
    // cadena de conexión base de datos
    "DefaultConnection": ""
  },
  // Configuraciones
  "AppSettings": {
    // Secret para token JWT
    "Secret": "",
    // Issuer para token JWT
    "Issuer": "",
    // Audince para token JWT
    "Audience": ""
  }
}
```

### Secrets

Para generar el secret de token JWT se puede utilizar la herramienta **openssl**

```shell
  openssl rand -base64 32
```

### ToDo's

- [ ] Implementación de Roles
- [ ] Update y Eliminación / reactivación Usuarios
- [ ] Refresh tokens
- [X] Registro y Login de Usuarios
- [X] JWT Token
- [X] CRUD Estados
- [X] CRUD Paises
- [X] CRUD Departamentos
- [X] CRUD Locacion
- [X] CRUD Vehiculos
- [X] CRUD Rutas
- [ ] CRUD Viajes
- [ ] CRUD Reservas
- [ ] CRUD Métodos de pago
- [ ] CRUD Pagos
- [ ] Lógica de reservas - WS
