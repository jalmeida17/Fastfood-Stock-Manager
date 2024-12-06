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
    [HttpGet("get-all")]
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
    [HttpGet("get-by-{id}")]
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
    [HttpPost("create")]
    public ActionResult<FastfoodStock> Create(FastfoodStock fastfoodStock)
    {
        FastfoodStockService.Add(fastfoodStock);
        return CreatedAtAction(nameof(Get), new { id = fastfoodStock.Id }, fastfoodStock);
    }

    // PUT action
    [HttpPut("update")]
    public IActionResult Update(FastfoodStock fastfoodStock)
    {
        var stocks = FastfoodStockService.Get(fastfoodStock.Id);
        if (stocks == null || fastfoodStock.Id <= 0)
        {
            return NotFound("Aucun stock trouvé.");
        }
        FastfoodStockService.Update(fastfoodStock);

        return Ok(stocks);
    }

    // DELETE action
    [HttpDelete("delete-by-{id}")]
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

    // Requêtes de Yoann
    [HttpPut("create-or-update")]
    public IActionResult CreateOrUpdate(FastfoodStock fastfoodStock)
    {
        var existingStock = FastfoodStockService.Get(fastfoodStock.Id);


        var stocks = FastfoodStockService.Get(fastfoodStock.Id);
        if (existingStock == null)
        {
            FastfoodStockService.Add(fastfoodStock);
        }
        else
        {
            FastfoodStockService.Update(fastfoodStock);
        }
        return Ok();
    }

    [HttpGet("get-coke-sum")]
    public ActionResult<int> GetCokeSum()
    {
        var stocks = FastfoodStockService.GetCokeSum();
        if (stocks == 0)
        {
            return NotFound("Aucun coca-cola trouvé.");
        }
        var response = "Getting total nb of cokes : " + stocks;
        return Ok(response);
    } 



}
