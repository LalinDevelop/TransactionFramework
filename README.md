# TransactionFramework

Biblioteca **.NET / C#** reutilizable para consumir API REST basadas en transacciones mediante `HttpClient`.

El framework proporciona componentes reutilizables para enviar solicitudes de transacción, gestionar las respuestas 
de la API, serializar y deserializar JSON, mapear los resultados de la transacción a objetos fuertemente tipados y 
administrar los puntos finales de la API y los estados de las transacciones.

## Funcionalidades

* Comunicación HTTP mediante `HttpClient`
* Ejecución de transacciones síncrona y asíncrona
* Serialización y deserialización JSON
* Mapeo genérico de respuestas
* Modelos de solicitud y respuesta de transacción
* Métodos de extensión reutilizables
* Configuración de puntos finales de la API
* Gestión de errores HTTP y tiempos de espera
* Mapeo genérico de resultados de transacción
* Modelos fuertemente tipados para la comunicación con la API

## Componentes principales

### `TransactionApiClient`

Cliente principal para comunicarse con la API de transacciones.

Proporciona métodos para:

* Solicitudes síncronas
* Solicitudes asíncronas
* Manejo de respuestas JSON
* Ejecución de transacciones
* Mapeo genérico de resultados de transacciones

### `TransactionHelper`

Proporciona métodos de extensión reutilizables para:

* Objeto → JSON
* JSON → Objeto
* JSON → Lista
* Respuesta de transacción → objetos fuertemente tipados

### `TransactionRequestModel`

Define la estructura estándar para las solicitudes de transacción, incluyendo:

* Token
* Usuario
* Aplicación
* Nombre de host
* IP
* Transacción
* Estado
* Mensaje
* Atributos de transacción

### `TransactionResponseModel`

Define la estructura de respuesta estándar de la API y proporciona una colección genérica `Results` para los datos de la transacción.

### `TransactionEndPoints`

Centraliza la configuración de los puntos finales de la API para diferentes entornos, como:

* Local
* Desarrollo
* Producción

### `TransactionStatus`

Proporciona constantes estandarizadas para el estado de las transacciones:

* Solicitud
* Éxito
* Advertencia
* Error
* Tiempo de espera agotado

## Ejemplo

```csharp
var client = new TransactionApiClient(

"https://localhost:7007",

30
);

var request = new TransactionRequestModel
{
Token = "token",
User = "user",
Application = "MyApplication",
Transaction = "GetData",
Status = TransactionStatus.REQUEST
};

string response = client.ExecuteTransactionSync(request);
```

## Tecnologías

* C#
* .NET
* HttpClient
* API REST
* JSON
* System.Text.Json
* Programación genérica
* Async/Await

## Objetivo

El objetivo de este proyecto es proporcionar una abstracción reutilizable para aplicaciones que se comunican con API orientadas a transacciones, reduciendo la duplicación de código para el manejo de HTTP y JSON en diferentes aplicaciones .NET.
