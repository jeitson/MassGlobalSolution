# MassGlobalSolution
## Instrucciones
- 1. Verificar en las propiedades de la solución que esten configurados para iniciar al tiempo el proyecto web y el proyecto API.
- 2. Iniciar el proyecto con el boton de compilación habitual para que ambos proyectos inicien.
- 3. Ud podra ver que se cargan ambos proyectos e interactuar con el proyecto web.

## Validaciones ante posibles fallos de configuración
- 1. Verificar que la url de inicio del servicio sea en el puerto 49994, en caso de iniciar en otro puerto se debe modificar este numero de puerto en el archivo del proyecto web /app/employee.js linea 8.

## Esccenarios web y pruebas unitarias
- 1. Si el input esta vacio, se listan todos los empleados
- 2. Si en el input se escribe un código de empleado valido, solo se visualizará la información de ese empleado.
- 3. Si en el input se escribe un código menor a cero, el back arroja un mensaje de error que se muestra en el front.
- 4. Si el código ingresado no corresponde con un empleado, no se visualiza ninguna fila en la tabla.
