using AI_PoweredEcommerce.Data;
using AIPoweredEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace AI_PoweredEcommerce.Services
{
    public class CartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddToCart(string userId, int productId)
        {
            var existingItem = await _context.CartItems
                .FirstOrDefaultAsync(c =>
                    c.UserId == userId &&
                    c.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _context.CartItems.Add(new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<CartItem>> GetCartItems(string userId)
        {
            return await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

       
    }
}