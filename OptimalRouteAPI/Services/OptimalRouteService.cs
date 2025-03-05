using OptimalRouteAPI.Interfaces;
using OptimalRouteAPI.Models;

namespace OptimalRouteAPI.Services
{
     public class OptimalRouteService : IOptimalRouteService
     {
          public RouteResponse CalculateShortestRoute(RouteRequest routeRequest)
          {
               // Crear el grafo como un diccionario
               var graph = BuildGraph(routeRequest.Roads);

               // Aplicar el algoritmo de Dijkstra
               var result = Dijkstra(graph, routeRequest.Origin, routeRequest.Destination);

               return result;
          }

          private Dictionary<string, List<Road>> BuildGraph(List<Road> roads)
          {
               var graph = new Dictionary<string, List<Road>>();

               foreach (var road in roads)
               {
                    if (!graph.ContainsKey(road.From))
                         graph[road.From] = new List<Road>();
                    graph[road.From].Add(road);

                    if (!graph.ContainsKey(road.To))
                         graph[road.To] = new List<Road>();
                    // Añadir la carretera en ambas direcciones, si es un grafo no dirigido
                    graph[road.To].Add(new Road { From = road.To, To = road.From, Time = road.Time });
               }

               return graph;
          }

          private RouteResponse Dijkstra(Dictionary<string, List<Road>> graph, string origin, string destination)
          {
               // Inicializar las estructuras para el algoritmo de Dijkstra
               var distances = new Dictionary<string, int>();
               var previousNodes = new Dictionary<string, string>();
               var nodes = new List<string>();

               foreach (var city in graph.Keys)
               {
                    distances[city] = int.MaxValue;  // Iniciar con una distancia infinita
                    previousNodes[city] = null;      // No hay nodo previo
                    nodes.Add(city);
               }

               distances[origin] = 0;  // La distancia al origen es 0

               while (nodes.Count > 0)
               {
                    // Obtener el nodo con la distancia más corta
                    var nearestNode = nodes.OrderBy(n => distances[n]).First();
                    nodes.Remove(nearestNode);

                    // Si llegamos al destino, no necesitamos seguir buscando
                    if (nearestNode == destination)
                         break;

                    // Revisar los vecinos
                    foreach (var road in graph[nearestNode])
                    {
                         var alternativeRoute = distances[nearestNode] + road.Time;
                         if (alternativeRoute < distances[road.To])
                         {
                              distances[road.To] = alternativeRoute;
                              previousNodes[road.To] = nearestNode;
                         }
                    }
               }

               // Reconstruir la ruta más corta
               var route = new List<string>();
               var currentNode = destination;

               while (currentNode != null)
               {
                    route.Insert(0, currentNode);
                    currentNode = previousNodes[currentNode];
               }

               // Retornar la respuesta con la ruta y el tiempo total
               return new RouteResponse
               {
                    Route = route,
                    TotalTime = distances[destination]
               };
          }
     }
}
