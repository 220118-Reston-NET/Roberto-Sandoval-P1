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
                            values(@costumerName, @costumerPhone, @costumerAddress, @costumerEmail, @costumerOrder";

        using (SqlConnection conn = new SqlConnection(""))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@costumerName", p_costumer.Name);
            command.Parameters.AddWithValue("@costumerPhone", p_costumer.Phone);
            command.Parameters.AddWithValue("@costumerAddress", p_costumer.Address);
            command.Parameters.AddWithValue("@costumerEmail", p_costumer.Email);
            command.Parameters.AddWithValue("@costumerOrder", "costumerOrder");

            command.ExecuteNonQuery();

        }

        return p_costumer;
    }

    public void addOrder(Costumer p_costumer, Orders p_order)
    {
        string sqlQuery = @"insert into Orders
                            values(@orderStore, @orderPrice";

        /*
        public List<LineItems> _itemList;
        public string StoreFront { get; set; }
        public double Price { get; set; }
        public StoreFront store;
        */

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@orderStore", p_order.StoreFront);
            command.Parameters.AddWithValue("@orderPrice", p_order.Price);

            command.ExecuteNonQuery();

        }
        
    }

    public List<Costumer> ListOfCostumers()
    {
        List<Costumer> costumerList = new List<Costumer>();

        string sqlQuery = @"select * from Costumer";

        using (SqlConnection con = new SqlConnection(_connectionString))
        { 
            con.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                costumerList.Add(new Costumer(){
                    CostumerId = reader.GetInt32(0), 
                    Name = reader.GetString(1),
                    Phone = reader.GetString(2),
                    Address = reader.GetString(3),
                    Email = reader.GetString(4)
                    //_orders = reader.GetInt32(5)
                });
            }
        }

        return costumerList;
    }

    public List<Products> ListOfProducts()
    {
        List<Products> costumerList = new List<Products>();

        string sqlQuery = @"select * from Products";

        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            con.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, con);
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

        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            con.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                storeList.Add(new StoreFront(){
                    Name = reader.GetString(0),
                    Address = reader.GetString(1)
                });
            }
        }

        /*
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Products> _productList;
        public List<Orders> _odersList;
        */

        return storeList;
    }

    
}