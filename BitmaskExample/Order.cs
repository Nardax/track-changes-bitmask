namespace BitmaskExample;

public class Order
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Guid BillingPlanId { get; set; }

    public decimal Price { get; set; } = decimal.Zero;

    public int Quantity { get; set; }

    public TrackedOrderProperties ChangedProperties { get; set; }

    public Order()
    {
        ChangedProperties = TrackedOrderProperties.Id
            | TrackedOrderProperties.BillingPlanId
            | TrackedOrderProperties.Price
            | TrackedOrderProperties.Quantity;
    }

    public bool PropertyChanged(TrackedOrderProperties property)
    {
        return (ChangedProperties & property) != 0;
    }
}
