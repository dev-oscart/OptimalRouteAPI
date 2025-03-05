# OptimalRouteAPI
# Lo primero que hice fue crear el repositorio en github con una nueva rama llamada "Wip" de "Work in progress"
# Ya cloné el repositorio en una carpeta.
# Ya cree el proecto como API en .NET Core
# Creación de modelos para uso en el body del request
# Implementé los modelos Road y RouteRequest para el manejo del body del request
# Creé el controlador OptimalRouteAPI con funcionalidad por defecto para tenerlo de reserva.
# Se crearon la interfaz IOptimalRouteService y el servicio que la implementa OptimalRouteService para no depender de objetos para su ejecución.
# Se inyectaron como servicio en el archivo program.cs
# Se añadió una variable privada para la ejecución del método de cálculo.
# Realicé un análisis planteando en un diagrama el caso mencionado y parece un grafo o una figura muy fea.
# Como no me acuerdo tanto de la lógica de grafos y para ahorrar tiempo, utilicé chat GPT para obtener la lógica del cálculo de la ruta. En mi mente pensaba en algo con ciclos, pero creo que no es óptimo.
# Ya implementé la lógica en mi código, sólo estoy pendiente de probarla.