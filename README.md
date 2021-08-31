# Proyecto Juego Unity Corte 
_Juego basado en una nave espacial que busca destruir todos los animales de una granja por medio de el disparo de pequeños proyectiles _

## Autores ✒️

* **Brayan David Acosta** 
* **Rafael Santiago Rincón**
* **Julián Rodríguez Sánchez**

## Requisitos del proyecto 🚀

* Implementación de la mecánica de vidas 
* Implementación de mecánica de disparo cargado 

### Mecánica de vidas
_Para la creación de corazones, se colocaron corazones arriba de los personajes, se volvieron hijos del enemigo. Para que se comportara como una vida se necesitaba que un corazón pasará de estar lleno a estar vacío, es por esto que se empleó la función encargada de hacer el cambio de corazones. Además se creó una variable llamada “vida”, esta servía para definir qué tan llenos están los corazones, y a su vez especificar cuánta vida le quedaba al personaje, al llegar a 0 el enemigo muere. También se agregó una condición, de que cuando hubiese una colisión y la variable “vida” fuese igual a 0 el personaje se destruía, de ser contrario se restará 1 a la variable, también se le restaba a los hijos para que el sprite cambiará. Finalmente se crearon los hijos a través de código, los personajes no tienen corazón directamente sino que este se les asignaba por código._

### Mecánica disparo cargado
_Para hacer un disparo diferente, en este caso el disparo cargado ,se creó una variable llamada “carga”. Se creó otro sprite con una bala de diferente color, que además tenía como condición de que cuando se estuviese presionando la barra espaciadora, se añadiera valor a la variable “carga”, tan pronto la variable llegue a 100  y se suelte la tecla espacio, se dispara este tipo de bala. Para distinguir el daño entre los 2 disparos, ambos tienen una etiqueta distinta, la bala cargada tenía la etiqueta “superbala”, si “bala” colisionaba con el enemigo le quitaba 1 de vida, si la colisión era con la superbala le quitaba 2 de vida.




