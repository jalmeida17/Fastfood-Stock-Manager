using ContosoPizza.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LEARNING_.NET_API_ANGULAR.Controllers;

[ApiController]
[Route("[controller]")]
public class FastfoodStockController : ControllerBase
{
    private readonly ILogger<FastfoodStockController> _logger;

    public FastfoodStockController(ILogger<FastfoodStockController> logger)
    {
        _logger = logger;
    }

   
    // GET all action
    [HttpGet]
    public ActionResult<FastfoodStock[]> GetAll()
    {
        var stocks = FastfoodStockService.GetAll();
        if (stocks == null || stocks.Count == 0)
        {
            return NotFound("Aucun stock trouvé.");
        }
        return Ok(stocks);
    }
       

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<FastfoodStock> Get(int id)
    {
        var stocks = FastfoodStockService.Get(id);
        if (stocks == null || id <= 0)
        {
            return NotFound("Aucun stock trouvé.");
        }
        return Ok(stocks);
    }

    // POST action
    [HttpPost]
    public IActionResult Create(FastfoodStock fastfoodStock)
    {
        FastfoodStockService.Add(fastfoodStock);
        return CreatedAtAction(nameof(Get), new { id = fastfoodStock.Id }, fastfoodStock);
    }

    // PUT action
    [HttpPut]
    public IActionResult Update(FastfoodStock fastfoodStock)
    {
        var stocks = FastfoodStockService.Get(fastfoodStock.Id);
        if (stocks == null || fastfoodStock.Id <= 0)
        {
            return NotFound("Aucun stock trouvé.");
        }
        FastfoodStockService.Update(fastfoodStock);
        var response = "Changement du stock N*" + stocks.Id;
        return Ok(stocks);
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var stocks = FastfoodStockService.Get(id);
        if (stocks == null || id <= 0)
        {
            return NotFound("Aucun stock trouvé.");
        }
        FastfoodStockService.Delete(id);
        var response = "Supression de stock N*" + stocks.Id;
        return Ok(response);

    }

}
