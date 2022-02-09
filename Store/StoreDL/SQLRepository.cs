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
        string sqlQuery = @"insert into Costumer
                            values(@copstumerId, @costumerName, @costumer, @costumerAddress, @costumerEmail";

        using (SqlConnection conn = new SqlConnection(""))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@costumerName", p_costumer.Name);
            command.Parameters.AddWithValue("@costumerPhone", p_costumer.Phone);
            command.Parameters.AddWithValue("@costumerAddress", p_costumer.Address);
            command.Parameters.AddWithValue("@costumerEmail", p_costumer.Email);

            command.ExecuteNonQuery();

        }

        return p_costumer;
    }

    public void addOrder(Costumer p_costumer, Orders p_order)
    {
        string sqlQuery = @"insert into Orders
                            values(@orderNumber, @costumerId, @prodcutID, @storeNumber";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@orderNumber", p_order.OrderNumber);
            command.Parameters.AddWithValue("@costumerId", p_order.CostumerId);
            command.Parameters.AddWithValue("@storeNumber", p_order.CostumerId);
            command.Parameters.AddWithValue("@orderTotal", p_order.OrderTotal);

            command.ExecuteNonQuery();

        }
        
    }

    public List<Costumer> ListOfCostumers()
    {
        List<Costumer> costumerList = new List<Costumer>();

        string sqlQuery = @"select * from Costumer";

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
                    Name = reader.GetString(1),
                    Price = reader.GetDouble(2),
                    Description = reader.GetString(3),
                    Category = reader.GetString(4)
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

    public List<Orders> ListOfOrders()
    {
        List<Orders> orderList = new List<Orders>();

        string sqlQuery = @"select * from Orders";

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
    

    
}