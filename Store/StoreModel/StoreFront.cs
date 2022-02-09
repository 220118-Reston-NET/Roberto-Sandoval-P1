namespace StoreModel;
public class StoreFront
{
    public int StoreNumber { get; set; }
    public string StoreName { get; set; }
    public string StoreAddress { get; set; }

    //public List<Products> _productList;
    //public List<Orders> _odersList;

    public StoreFront()
    {
        StoreNumber = 000;
        StoreName = ".StoreName";
        StoreAddress = ".StoreAddress";

    }

    public override string ToString()
    {
        return $"Name: {StoreName}\nAddress: {StoreAddress}";
    }
    

}