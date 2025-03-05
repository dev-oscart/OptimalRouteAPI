namespace OptimalRouteAPI.Models
{
     public class RouteRequest
     {
          public List<string> Cities { get; set; } = new List<string>();
          public List<Road> Roads { get; set; } = new List<Road>();
          public string Origin { get; set; } = String.Empty;
          public string Destination { get; set; } = String.Empty;
     }

     public class RouteResponse
     {
          public List<string> Route { get; set; }
          public int TotalTime { get; set; }
     }
}
