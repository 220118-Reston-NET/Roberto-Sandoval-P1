using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModel;
using Serilog;

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
            Log.Information($"User succesfully added {p_costumer.CostumerId} to datbase");
            return Created("Successfully added", _costumerBL.AddCostumer(p_costumer));
        }
        catch (System.Exception error)
        {
            Log.Information($"Addidng costumer {p_costumer.CostumerId} resulted to exception {error.Message}");
            return Conflict(error.Message);
        }
    }

    [HttpGet("FindCostumerById")]
    public IActionResult GetCostumerById(int costumerId)
    {
        try
        {
            Log.Information($"User successfully found costumer {costumerId} in database");
            return Ok(_costumerBL.FindCostumer(costumerId));
        }
        catch (System.Exception)
        {
            Log.Information($"Costumer {costumerId} was not found in databse");
            return NotFound();
        }
    }

    [HttpGet("GetAllCostumers")]
    public IActionResult GetAllCostumers()
    {
        try
        {   
            Log.Information("User successfully got list of costumers");
            return Ok(_costumerBL.GetAllCostumers());
        }
        catch (SqlException error)
        {
            Log.Information($"GetAllCostumers exited with SQL exception {error.Message}");
            return Conflict(error.Message);
        }
    }

    [HttpGet("GetCostumerOrderHistory")]
    public IActionResult GetOrderCostumerHistory(int costumerId)
    {
        try
        {
            Log.Information($"User successfully got order history for costumer {costumerId}");
            return Ok(_costumerBL.orderHistory(costumerId));
        }
        catch (System.Exception error)
        {
            Log.Information($"Get order history for costumer {costumerId} exited with exception {error.Message}");
            return Conflict(error.Message);
        }
    }

    [HttpGet("GetLocationInventory")]
    public IActionResult GetLocationInventory(int storeNumber)
    {
        try
        {
            Log.Information($"User successfully got inventory for store {storeNumber}");
            return Ok(_storeFrontBL.listInventory(storeNumber));
        }
        catch (System.Exception error)
        {
            Log.Information($"Get inventory for store {storeNumber} exited with exception {error.Message}");
            return Conflict(error.Message);
        }
    }

    [HttpPost("ReplenishInventory")]
    public IActionResult ReplenishInventory([FromBody] List<StoreInventory> inventoryList, [FromRoute] int managerId, [FromRoute] int ManagerPassword)
    {
        try
        {
            Log.Information($"Manager {managerId} successfully added stock to inventory for store {inventoryList[0].StoreNumber}");
            return Created("Successfully added", _storeFrontBL.addInventory(inventoryList, managerId, ManagerPassword));
        }
        catch (System.Exception error)
        {
            Log.Information($"Replenish order from {managerId} for store {inventoryList[0].StoreNumber} exited with exception {error.Message}");
            return Conflict(error.Message);
        }
    }

    [HttpPost("PlaceOrder")]
    public IActionResult PlaceOrder([FromBody] List<Products> orderProducts, [FromRoute] Costumer orderCostumer, [FromRoute] int orderStoreNumber)
    {
        try
        {
            Log.Information($"Order for costumer {orderCostumer.CostumerId} placed successfully from store {orderStoreNumber}");
            return Created("Successfully processed order for costumer: ", _costumerBL.processOrder(orderProducts, orderCostumer, orderStoreNumber));
        }
        catch (System.Exception error)
        {
            Log.Information($"Order for costumer {orderCostumer.CostumerId} exited with exception {error.Message}");
            return Conflict(error.Message);
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

    // // POST: api/Store
    // [HttpPost]
    // public void Post([FromBody] string value)
    // {
    // }

    // // PUT: api/Store/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // // DELETE: api/Store/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
}

