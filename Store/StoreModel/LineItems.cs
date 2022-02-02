namespace StoreModel;
public class LineItems
{
    public int OrderNumber { get; set; } // First foreign key
    public int ProductId { get; set; } // Second foreign key
    public string Product { get; set; }
    public int Quantity { get; set; }
    

    public override string ToString()
    {
        return $"Name of Product: {Product}\nQuantity: {Quantity}";
    }
    
}