using BitmaskExample;

Console.WriteLine("Hello, World!");

var orderId = 1;
var billingPlanId = Guid.NewGuid();

Console.WriteLine("\n\nOrderV1");

// this initial version by default has all properties as changed because it is new
var orderV1 = new Order
{
    Id = orderId,
    Name = "sample order",
    Description = "description of the order",
    BillingPlanId = billingPlanId,
    Price = 10.5m,
    Quantity = 1,
};

// checking any property to see if it has changed will result in true
var idHasChanged = orderV1.ChangedProperties & TrackedOrderProperties.Id;

if (TrackedOrderProperties.Id == (orderV1.ChangedProperties & TrackedOrderProperties.Id))
{
    Console.WriteLine("Order.Id has changed in V1");
}

Console.WriteLine("\n\nOrderV2");
// ... system that generates a second version of the order goes here ...

// quantity has changed from 1 to 5
var orderV2 = new Order
{
    Id = orderId,
    Name = "sample order",
    Description = "description of the order",
    BillingPlanId = billingPlanId,
    Price = 10.5m,
    Quantity = 5,
};

// because the only thing that has changed is the quantity the ChangedProperties is set correctly
orderV2.ChangedProperties = TrackedOrderProperties.Quantity;

if (TrackedOrderProperties.Id != (orderV2.ChangedProperties & TrackedOrderProperties.Id))
{
    Console.WriteLine("Order.Id has NOT changed in V2");
}

if (TrackedOrderProperties.Quantity == (orderV2.ChangedProperties & TrackedOrderProperties.Quantity))
{
    Console.WriteLine("Order.Quantity has changed in V2");
}

Console.WriteLine("\n\nOrderV3");
// ... system that generates a third version of the order goes here ...

// price and quantity has changed
var orderV3 = new Order
{
    Id = orderId,
    Name = "sample order",
    Description = "description of the order",
    BillingPlanId = billingPlanId,
    Price = 12.5m,
    Quantity = 7,
};

orderV3.ChangedProperties = TrackedOrderProperties.Price | TrackedOrderProperties.Quantity;

// system that receives the new order cares about price and quantity changes
// using a helper method on Order to test for property changed to simplify the checking for flags

if (!orderV3.PropertyChanged(TrackedOrderProperties.Id))
{
    Console.WriteLine("Order.Id has NOT changed in V3");
}
if (orderV3.PropertyChanged(TrackedOrderProperties.Price | TrackedOrderProperties.Quantity))
{
    Console.WriteLine("Order.Price or Order.Quantity has changed in V3");
}