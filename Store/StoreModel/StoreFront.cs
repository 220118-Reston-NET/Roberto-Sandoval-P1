namespace StoreModel;
public class StoreFront
{
    public string Name { get; set; }
    public string Address { get; set; }

    public List<Products> _productList;
    public List<Orders> _odersList;

    public override string ToString()
    {
        return $"Name: {Name}\nAddress: {Address}";
    }
    

}