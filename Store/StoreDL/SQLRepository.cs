using System.Data.SqlClient;
using StoreModel;

namespace StoreDL;

public class SQLRepository : IRepository
{
    private readonly string _connectionString;
    public SQLRepository(string p_connectionString)
    {
        _connectionString = p_connectionString;
    }

    public Costumer AddCostumer(Costumer p_costumer)
    {
        string sqlQuery = @"insert into Costumers
                            values(@costumerId, @costumerName, @costumerPhone, @costumerAddress, @costumerEmail)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@costumerId", p_costumer.CostumerId);
            command.Parameters.AddWithValue("@costumerName", p_costumer.Name);
            command.Parameters.AddWithValue("@costumerPhone", p_costumer.Phone);
            command.Parameters.AddWithValue("@costumerAddress", p_costumer.Address);
            command.Parameters.AddWithValue("@costumerEmail", p_costumer.Email);

            command.ExecuteNonQuery();

        }

        return p_costumer;
    }

    public void addOrder(List<LineItems> p_lineItemsList, Orders p_order)
    {
        string sqlQuery = @"insert into Orders
                            values(@orderNumber, @costumerId, @storeNumber";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@orderNumber", p_order.OrderNumber);
            command.Parameters.AddWithValue("@costumerId", p_order.CostumerId);
            command.Parameters.AddWithValue("@storeNumber", p_order.StoreNumber);
            command.Parameters.AddWithValue("@orderTotal", p_order.OrderTotal);

            command.ExecuteNonQuery();

        }
        
    }

    public List<Costumer> ListOfCostumers()
    {
        List<Costumer> costumerList = new List<Costumer>();

        string sqlQuery = @"select * from Costumers";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        { 
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                costumerList.Add(new Costumer(){
                    CostumerId = reader.GetInt32(0), 
                    Name = reader.GetString(1),
                    Phone = reader.GetString(2),
                    Address = reader.GetString(3),
                    Email = reader.GetString(4)
                });
            }
        }

        return costumerList;
    }

    public List<Products> ListOfProducts()
    {
        List<Products> costumerList = new List<Products>();

        string sqlQuery = @"select * from Products";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                costumerList.Add(new Products(){
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    ProductPrice = reader.GetDouble(2),
                    ProductDescription = reader.GetString(4),
                    ProductCategory = reader.GetString(5)
                });
            }
        }

        return costumerList;
    }

    public List<StoreFront> ListOfStores()
    {
        List<StoreFront> storeList = new List<StoreFront>();

        string sqlQuery = @"select * from Stores";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                storeList.Add(new StoreFront(){
                    StoreNumber = reader.GetInt32(0),
                    StoreName = reader.GetString(1),
                    StoreAddress = reader.GetString(2)
                });
            }
        }

        return storeList;
    }

    public List<Orders> ListOfOrders(int p_costumerId)
    {
        List<Orders> orderList = new List<Orders>();

        string sqlQuery = @"select * from Orders o where o.costumerId ="+p_costumerId;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orderList.Add(new Orders(){
                    OrderNumber = reader.GetInt32(0),
                    CostumerId = reader.GetInt32(1),
                    StoreNumber = reader.GetInt32(3)
                });
            }
        }

        return orderList;
    }

    public List<StoreInventory> ListInventory(int p_storeNumber)
    {
        List<StoreInventory> inventoryList = new List<StoreInventory>();

        string sqlQuery = @"select s.storeNumber, p.productId, p.productName, p.productDescription, s.quantity
             from Products p inner join StoreInventory s on p.productId=s.productId" ;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                inventoryList.Add(new StoreInventory(){
                    StoreNumber = reader.GetInt32(0),
                    ProductId = reader.GetInt32(1),
                    ProductName = reader.GetString(2),
                    ProductDescription = reader.GetString(3),
                    Quantity= reader.GetInt32(4)
                });
            }
        }

        return inventoryList;

    }

    public void subtractInventory(List<StoreInventory> p_stock)
    {
        string sqlQuery = @"";

    }

    public void addInventory(List<StoreInventory> p_stock)
    {
        string sqlQuery = @"";
    }

    public void subtractInventory(List<Products> p_products, int p_storeNumber)
    {
        throw new NotImplementedException();
    }

    public int createCostumerId()
    {
        int costumerId = 1000;

        string sqlQuery = @"select count(*) from costumers";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                costumerId += reader.GetInt32(0)*10;
            }
        }

        return costumerId;
    }

    public int createOrderId()
    {
        int orderNumber = 10000;

        return orderNumber;
    }
}