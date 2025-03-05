using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptimalRouteAPI.Interfaces;
using OptimalRouteAPI.Models;

namespace OptimalRouteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptimalRouteAPIController : ControllerBase
    {
          private IOptimalRouteService _optimalRouteService;

          public OptimalRouteAPIController (IOptimalRouteService optimalRouteService)
          {
               _optimalRouteService = optimalRouteService;
          }

          [HttpPost("optimal-route")]
          public IActionResult CalculateShortestRoute([FromBody] RouteRequest bodyRequest)
          {
               try
               {
                    RouteResponse result;

                    if (bodyRequest.Cities == null || bodyRequest.Cities.Count == 0 || bodyRequest.Roads == null || bodyRequest.Roads.Count == 0 || String.IsNullOrWhiteSpace(bodyRequest.Origin) || String.IsNullOrWhiteSpace(bodyRequest.Destination))
                         return BadRequest(new
                         {
                              Message = "There is mmissing information from the input. Please, verify it!"
                         });

                    result = _optimalRouteService.CalculateShortestRoute(bodyRequest);

                    return Ok();
               }
               catch(Exception ex)
               {
                    return StatusCode(500, new
                    {
                         StatusCode = 500,
                         Message = "Oops! Something went wrong.",
                         Error = ex.Message
                    });
               }
          }
    }
}
