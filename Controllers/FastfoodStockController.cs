using ContosoPizza.Services;
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
    public ActionResult<List<FastfoodStock>> GetAll() =>
        FastfoodStockService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<FastfoodStock> Get(int id)
    {
        var fastfoodStock = FastfoodStockService.Get(id);

        if(fastfoodStock == null)
            return NotFound();

        return fastfoodStock;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(FastfoodStock fastfoodStock)
    {
        FastfoodStockService.Add(fastfoodStock);
        return CreatedAtAction(nameof(Get), new { id = fastfoodStock.Id }, fastfoodStock);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, FastfoodStock fastfoodStock)
    {
        if (id != fastfoodStock.Id)
            return BadRequest();

        var existingFastfoodStock = FastfoodStockService.Get(id);
        if (existingFastfoodStock is null)
            return NotFound();

        FastfoodStockService.Update(fastfoodStock);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var fastfoodStock = FastfoodStockService.Get(id);

        if (fastfoodStock is null)
            return NotFound();

        FastfoodStockService.Delete(id);

        return NoContent();
    }


}
