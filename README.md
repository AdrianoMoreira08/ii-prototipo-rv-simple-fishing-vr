# Simple Fishing VR

*¡Pesca virtual, donde cada lance es una aventura y cada captura una victoria!*

**Autores:**
- Diego Herrera Mendoza.
- Ginés Cruz Chávez.
- Adriano dos Santos Moreira.

## Cuestiones importantes para el uso
Nuestra aplicación es un simulador de pesca en el que la mecánica principal es
lanzar la caña y recogerla cuando pican los peces. El juego está creado para ser
disfrutado en RV, preferiblemente con un dispositivo que permita el control por
gestos como podría ser las *Meta Quest 2*, *Valve Index* o *HTC Vive*.

## Hitos de programación
- Controles en realidad virtual: Se ha implementado la capacidad de usar los mandos nativos de los dispositivos de realidad virtual en la aplicación
- Físicas: El lanzamiento del cebo y la interacción con la bobina de pesca se basa en físicas de Unity. El cebo también dispone de un sistema de flotabilidad sobre el agua.
- Eventos: Los peces y la caña mantienen comunicación mediante eventos para saber que pez está siendo pescado. Así como el script de la bobina tiene un evento para que la caña tenga su comportamiento.

## Aspectos destacados de la aplicación
- **Simulación de peces vivos.** En la porción de mar frente al usuario se
observan sombras de peces. Estos peces se mueven cerca de la orilla con
inteligencia artificial, esperando a ser atraídos por el cebo de la caña.

- **Pesca interactiva.** Lanza la caña al agua para poder pescar. Con paciencia,
los peces acabarán picando el anzuelo. En ese momento, usa la mano izquierda para
hacer girar el carrete y recoger el sedal con el pez atrapado.

- **Inmersión en el escenario.** El usuario tiene la libertad de moverse
por una isla desde la que puede pescar. La escena de juego está ambientada con
palmeras y demás detalles de la naturaleza.

- **Interacción física.** Como jugador, tienes control sobre los objetos del
escenario. Puedes manejar la caña de pescar con total libertad, como si la
sujetases en la vida real, y agarrar los peces que consigas coger.


## Sensores de interfaces multimodales
Cuando recuperas el hilo, se hace vibrar el mando con el que se sujeta la caña de pescar,
logrando una respuesta háptica a la acción, lo cual refuerza la kinestética del
juego.

Como se trata de una aplicación desarrollada para un dispositivo de VR avanzado,
se hace uso de los sensores de movimiento para localizarse en el espacio del
juego.

## Gif animado de ejecución

## Acta de los acuerdos del trabajo en equipo

En general, se desarrolló la aplicación trabajando conjuntamente en diferentes
sesiones.

- **Adriano**:
  - Modelo de la caña de pescar.
  - Scripting: Controles.
- **Diego**:
  - Acomodación de la escena.
  - Scripting: Peces.
- **Ginés**:
  - Modelo de la isla y palmeras.
  - Scripting: Caña de pescar.
