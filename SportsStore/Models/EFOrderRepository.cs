using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext context;
        public EFOrderRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders =>
            context.Orders.Include(o => o.Lines)
            .ThenInclude(l => l.Product);
        public void SaveOrder(Order order)
        {
            // Attach the related Product entities to the context for each line item in the order.
            // This ensures that the products are tracked by the context and avoids unnecessary updates or inserts.
            context.AttachRange(order.Lines.Select(l => l.Product));

            // If the OrderID is 0, it indicates a new order, so add it to the context.
            // The context will track the new order, and it will be inserted into the database when SaveChanges is called.
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }

            // Save the changes to the context, which will update or insert the order and its line items in the database.
            context.SaveChanges();
        }

    }
}
