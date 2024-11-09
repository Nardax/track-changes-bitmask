namespace BitmaskExample;

[Flags]
public enum TrackedOrderProperties
{
    None = 0,
    Id = 1,
    BillingPlanId = 2,
    Price = 4,
    Quantity = 8,
}
