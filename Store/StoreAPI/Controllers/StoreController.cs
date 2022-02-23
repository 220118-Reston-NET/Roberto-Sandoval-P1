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

    [HttpPost("AddCostumer")]
    public IActionResult AddCostumer([FromBody] Costumer p_costumer)
    {
        try
        {
            return Created("Successfully added", _costumerBL.AddCostumer(p_costumer));
        }
        catch (System.Exception err)
        {
            return Conflict(err.Message);
        }
    }

    [HttpGet("FindCostumerById")]
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

    [HttpGet("GetAllCostumers")]
    public IActionResult GetAllPokemon()
    {
        try
        {   
            return Ok(_costumerBL.GetAllCostumers());
        }
        catch (SqlException)
        {
            return NotFound();
        }
    }

    [HttpGet("GetCostumerOrderHistory")]
    public IActionResult GetOrderCostumerHistory(int costumerId)
    {
        try
        {
            return Ok(_costumerBL.orderHistory(costumerId));
        }
        catch (System.Exception)
        {
            return NotFound();
        }
    }

    [HttpGet("GetLocationInventory")]
    public IActionResult GetLocationInventory(int storeNumber)
    {
        try
        {
            return Ok(_storeFrontBL.listInventory(storeNumber));
        }
        catch (System.Exception)
        {
            return NotFound();
        }
    }

    [HttpPost("ReplenishInventory")]
    public IActionResult ReplenishInventory([FromBody] List<StoreInventory> inventoryList, [FromRoute] int managerId, [FromRoute] int ManagerPassword)
    {
        try
        {
            return Created("Successfully added", _storeFrontBL.addInventory(inventoryList, managerId, ManagerPassword));
        }
        catch (System.Exception err)
        {
            return Conflict(err.Message);
        }
    }

    [HttpPost("PlaceOrder")]
    public IActionResult PlaceOrder([FromBody] List<Products> orderProducts, [FromRoute] Costumer orderCostumer, [FromRoute] int orderStoreNumber)
    {
        try
        {
            return Created("Successfully processed order for costumer: ", _costumerBL.processOrder(orderProducts, orderCostumer, orderStoreNumber));
        }
        catch (System.Exception err)
        {
            return Conflict(err.Message);
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

