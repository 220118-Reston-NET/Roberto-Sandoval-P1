namespace StoreModel;
public class LineItems
{
    public string Product { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"Name of Product: {Product}\nQuantity: {Quantity}";
    }
    
}