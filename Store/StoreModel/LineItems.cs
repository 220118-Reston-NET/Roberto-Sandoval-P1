namespace StoreModel;
public class LineItems
{
    public int OrderNumber { get; set; } // First foreign key
    public int ProductId { get; set; } // Second foreign key
    public int Quantity { get; set; }
    
    
}