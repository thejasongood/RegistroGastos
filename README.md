# Registro de Gastos con SQL Server

## Descripción
Este proyecto consiste en una aplicación de consola desarrollada en C# que utiliza ADO.NET para conectarse a SQL Server y consultar los gastos almacenados en una base de datos.

## Tecnologías utilizadas
- C#
- .NET
- SQL Server LocalDB
- ADO.NET
- Microsoft.Data.SqlClient

## Estructura del proyecto
- **Program.cs:** establece la conexión con la base de datos, consulta los gastos y calcula el total general.
- **Gasto.cs:** contiene las propiedades de cada gasto y el método `ToString()` para mostrar sus datos.
- **GastosDB:** base de datos que almacena la información de los gastos.

## Datos de los gastos
Cada registro contiene los siguientes campos:
- Id
- Descripcion
- Monto
- Categoria

## Funcionamiento
El programa se conecta a la base de datos `GastosDB`, consulta los registros de la tabla `Gastos` y muestra en consola el identificador, la descripción, el monto y la categoría de cada gasto. Al finalizar, calcula e imprime el total gastado.

Si no existen registros, muestra un mensaje indicando que no hay gastos registrados. También contempla errores relacionados con SQL Server.

## Requisitos
- Visual Studio
- SQL Server LocalDB
- Paquete NuGet `Microsoft.Data.SqlClient`

## Ejecución
1. Crear la base de datos `GastosDB` y la tabla `Gastos`.
2. Instalar el paquete `Microsoft.Data.SqlClient`.
3. Verificar la cadena de conexión en `Program.cs`.
4. Ejecutar el proyecto desde Visual Studio.
