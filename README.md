# RouletteApi
Implementar un API que represente una ruleta de apuestas online que cumpla las siguientes características:

- Endpoint de creación de nuevas ruletas que devuelva el id de la nueva ruleta creada.
- Endpoint de apertura de ruleta (el input es un id de ruleta) que permita las posteriores 
  peticiones de apuestas, este debe devolver simplemente un estado que confirme que la operación fue exitosa o denegada.
- Endpoint de apuesta a un número (los números válidos para apostar son del 0 al 36) o color (negro o rojo) de la ruleta 
  una cantidad determinada de dinero (máximo 10.000 dólares) a una ruleta abierta. nota: este enpoint recibe además de los 
  parámetros de la apuesta, un id de usuario en los HEADERS asumiendo que el servicio que haga la petición ya realizo una autenticación 
  y validación de que el cliente tiene el crédito necesario para realizar la apuesta.
- Endpoint de cierre apuestas dado un id de ruleta, este endpoint debe devolver el resultado de las apuestas hechas desde su apertura hasta 
  el cierre. El número ganador se debe seleccionar automáticamente por la aplicación al cerrar la ruleta y para las apuestas de tipo numérico 
  se debe entregar 5 veces el dinero apostado si atinan al número ganador, para las apuestas de color se debe entrega 1.8 veces el dinero apostado, 
  todos los demás perderán el dinero apostado.
- Endpoint de listado de ruletas creadas con sus estados (abierta o cerrada)
