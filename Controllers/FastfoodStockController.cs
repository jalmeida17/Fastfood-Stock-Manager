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
            return NotFound("Aucun stock trouv�.");
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
            return NotFound("Aucun stock trouv�.");
        }
        return Ok(stocks);
    }

    // POST action
    [HttpPost]
    public ActionResult<FastfoodStock> Create(FastfoodStock fastfoodStock)
    {
        FastfoodStockService.Add(fastfoodStock);
        return CreatedAtAction(nameof(Get), new { id = fastfoodStock.Id }, fastfoodStock);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] FastfoodStock fastfoodStock)
    {
        if (fastfoodStock == null || fastfoodStock.Id != id || id <= 0)
        {
            return BadRequest("Invalid request data.");
        }

        var stocks = FastfoodStockService.Get(id);
        if (stocks == null)
        {
            return NotFound("Aucun stock trouv�.");
        }

        FastfoodStockService.Update(fastfoodStock);

        return Ok(fastfoodStock);
    }


    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var stocks = FastfoodStockService.Get(id);
        if (stocks == null || id <= 0)
        {
            return NotFound("Aucun stock trouv�.");
        }
        FastfoodStockService.Delete(id);
        return Ok(stocks);

    }

    // Requ�tes de Yoann
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
        return Ok(stocks);
    }

    [HttpGet("get-coke-sum")]
    public ActionResult<int> GetCokeSum()
    {
        var stocks = FastfoodStockService.GetCokeSum();
        if (stocks == 0)
        {
            return NotFound("Aucun coca-cola trouv�.");
        }
        return Ok(stocks);
    } 



}
