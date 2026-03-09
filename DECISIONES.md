# Decisiones de Diseño

## 1. Estructura del Dominio
[¿Cómo modelaste las entidades? ¿Por qué?]
El dominio se modeló alrededor de la entidad Paquete, el cual es el objeto principal, dentro de esta entidad, se definen sus propiedades y comportamientos,
también se modeló la entidad Historial_Paquete_Estatus, la cual tiene como fin guardar todos los cambios de estado de un paquete y por último
se modeló la entidad Ruta, en la cual se utiliza para asignar las rutas de envío del paquete

## 2. Ubicación de Reglas de Negocio  
[¿Dónde pusiste las validaciones y por qué?]
Las reglas de negocio principales se colocaron en el dominio, mientras que las validaciones en la capa de aplicación utilizando FluentValidation, esto para tener separado las reglas de negocio con las validaciones.

## 3. Patrones Utilizados
[¿Qué patrones aplicaste? ¿Cuál fue tu razonamiento?]
Se utilizó Clean Architecture para separar las responsabilidades y CQRS para poder dividir las operaciones de lectura y escritura.

## 4. Trade-offs y Limitaciones
[¿Qué dejaste fuera por tiempo? ¿Cómo lo resolverías?]
Por limitación del tiempo no se puedieron realizar las pruebas unitarias, lo resolvería si hubiera un poco más de tiempo se agregarían para tener todo comprobado y sin error.

## 5. Supuestos
[¿Qué asumiste que no estaba explícito en los requerimientos?]
Pues se asumieron más que nada las relaciones entre paquete y estatus e historial_De_paguete_estatus, así como los números de estatus de cada Estado del paquete