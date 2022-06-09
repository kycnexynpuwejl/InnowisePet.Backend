using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Order.DAL.Repo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;
    
        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Guid id, Order order)
        {
            var orderFromDb = await _context.Orders.FindAsync(id);

            if (orderFromDb == null) return;

            orderFromDb.Firstname = order.Firstname;
            orderFromDb.Lastname = order.Lastname;
            orderFromDb.Address = order.Address;
            orderFromDb.City = order.City;
            orderFromDb.Country = order.Country;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var orderFromDb = await _context.Orders.FindAsync(id);

            if (orderFromDb == null) return;

            _context.Orders.Remove(orderFromDb);
            await _context.SaveChangesAsync();
        }
    }
}