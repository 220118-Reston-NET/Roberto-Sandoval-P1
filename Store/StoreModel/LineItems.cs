namespace StoreModel;
public class LineItems
{
    public int StoreNumber { get; set; } // First foreign key
    public int ProductId { get; set; } // Second foreign key
    public int Quantity { get; set; }
    
    
}