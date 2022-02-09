namespace StoreModel;
public class Orders
{
    public int OrderNumber { get; set; }
    public int CostumerId { get; set; }
    public int StoreNumber { get; set; }
    public double OrderTotal { get; set; }

    public Orders()
    {
        OrderNumber = 000;
    }

    public override string ToString()
    {
        return $"Order Number: {OrderNumber}\nOrder Total: {OrderTotal}";
    }

    

}

