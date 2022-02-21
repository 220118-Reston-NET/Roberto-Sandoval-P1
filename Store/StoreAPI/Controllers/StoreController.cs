using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StoreBL;
using StoreModel;

namespace StoreAPI.Controllers;

[Route("api/[controller]")] 
[ApiController]
public class StoreController : ControllerBase
{
    private IStoreFrontBL _storeFrontBL;
    private ICostumerBL _costumerBL;
    private IMemoryCache _memoryCache;

    public StoreController(IStoreFrontBL p_storeFrontBL, ICostumerBL p_costumerBL, IMemoryCache p_memoryCache)
    {
        _storeFrontBL = p_storeFrontBL;
        _costumerBL = p_costumerBL;
        _memoryCache = p_memoryCache;
    }

    [HttpPost("Add")]
        public IActionResult AddPokemon([FromBody] Costumer p_costumer)
        {
            try
            {
                return Created("Successfully added", _costumerBL.AddCostumer(p_costumer));
            }
            catch (System.Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

}