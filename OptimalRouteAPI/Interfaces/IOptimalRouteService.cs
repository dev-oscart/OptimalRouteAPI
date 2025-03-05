using OptimalRouteAPI.Models;

namespace OptimalRouteAPI.Interfaces
{
     public interface IOptimalRouteService
     {
          public RouteResponse CalculateShortestRoute(RouteRequest routeRequest);
     }
}
