# RunicWords

## Introducción
Este juego fue realizado como **Proyecto** 2D de entrega del trayecto profesional Desarrollo de Videojuegos con Unity del instituto [Image Campus](https://www.imagecampus.edu.ar).
## Game Design

### Concepto general
Es una juego SinglePlayer, en el que debes clickear sobre objetos llamados Runas con el fin sobrevivir durante un tiempo determinado. 

### Caracterísiticas generales
El tiempo de supervivencia está denotado como una barra dorada en la parte superior de la pantalla. 

La vida se visualiza como un fondo de agua que va disminuyendo hasta llegar al extremo inferior.

En cada nivel aumenta la cantidad de tiempo a sobrevivir, disminuye la cantidad de vida restante de supervivencia y la cantidad spawn de Runas.

Los cuatro tipos de Runas son:
  - Aumentar vida (color verde)
  - Disminuir vida (color naranja)
  - Aumentar tiempo de supervivencia (color amarillo)
  - Disminuir tiempo de supervivencia (color azulado)

### Arte
El arte 2D está realizado por un amigo que se desarrolla como artista digital (instagram: @introvernauta)

### Plataforma target
El juego fue pensado para plataformas __Mobile__ desde su inicio, pero para fines de entrega y comienzos en la industria, se generó y entregó el compilado para plataformas de __escritorio__.

Actualmente esta exportado para __WebGL__ y lo seguirá siendo.

## Game Development
- Patrones: 
  - Singleton: un AudioSource que no se destruye entre escenas. 
- Controladores: GameController, CanvasController, SoundController, etc.
- Parametrización de puntos de Spawn de Runas.
- Pooling de Runas.
- Ubicación aleatoria de Runas en puntos de Spawn.
- Herencia e Interfaces para trayectorias de Runas.
- Animaciones

Se ha eliminado partes de código y sprites por reserva de derechos de autor.

## Prueba el juego y envía feedback
El juego está compilado para plataforma __WebGL__: https://maurichamorro.github.io/RuneWords/

## Expectativas
No tiene fines comerciales, sino aplicar prácticas en el mundo de vodeojuegos, compartir conocimientos y experiencias.

Mejorar en Level Design.

## Contáctame
Puedes enviarme mensajes de correo electrónico a __mmchamoo@gmail.com__ o agregarme a [LinkedIn](https://www.linkedin.com/in/mauricio-manuel-chamorro).
