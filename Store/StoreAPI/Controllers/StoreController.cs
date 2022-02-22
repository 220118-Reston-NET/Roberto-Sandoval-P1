using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModel;

namespace StoreAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreController : ControllerBase
{
private IStoreFrontBL _storeFrontBL;
    private ICostumerBL _costumerBL;

    public StoreController(IStoreFrontBL p_storeFrontBL, ICostumerBL p_costumerBL)
    {
        _storeFrontBL = p_storeFrontBL;
        _costumerBL = p_costumerBL;
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

    [HttpGet("GetAllCostumers")]
        public IActionResult GetAllPokemon()
        {
            try
            {
                
                
                return Ok(_costumerBL.GetAllCostumers);
            }
            catch (SqlException)
            {
                //The API is responsible for sending the right resource and the right status code
                //In this case, if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
        }

    [HttpGet("{costumerId}")]
        public IActionResult GetCostumerById(int costumerId)
        {
            try
            {
                return Ok(_costumerBL.FindCostumer(costumerId));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    
    // // GET: api/Store
    // [HttpGet("GetAll")]
    // public IEnumerable<string> Get()
    // {
    //     return new string[] { "value1", "value2" };
    // }

    // // GET: api/Store/5
    // [HttpGet("{id}", Name = "Get")]
    // public string Get(int id)
    // {
    //     return "value";
    // }

    // POST: api/Store
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Store/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/Store/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

