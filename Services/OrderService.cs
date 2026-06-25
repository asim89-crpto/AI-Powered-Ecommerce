using AI_PoweredEcommerce.Data;
using AIPoweredEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace AI_PoweredEcommerce.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems!)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<List<Order>> GetOrders(string userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task PlaceOrder(string userId)
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
                return;

            var order = new Order
            {
                UserId = userId,
                TotalAmount = cartItems.Sum(
                    x => x.Quantity * x.Product!.Price),
                Status = "Pending"
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            foreach (var item in cartItems)
            {
                _context.OrderItems.Add(
                    new OrderItem
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Product!.Price
                    });
            }

            _context.CartItems.RemoveRange(cartItems);

            await _context.SaveChangesAsync();
        }



        public async Task<List<Product>> GetCustomersAlsoBought(int productId)
        {
            var orderIds = await _context.OrderItems
                .Where(oi => oi.ProductId == productId)
                .Select(oi => oi.OrderId)
                .Distinct()
                .ToListAsync();

            return await _context.OrderItems
                .Where(oi =>
                    orderIds.Contains(oi.OrderId) &&
                    oi.ProductId != productId)
                .Select(oi => oi.Product!)
                .Distinct()
                .Take(4)
                .ToListAsync();
        }
    }
}