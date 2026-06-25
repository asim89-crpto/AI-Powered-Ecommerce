using AI_PoweredEcommerce.Data;
using AIPoweredEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace AI_PoweredEcommerce.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var existingProduct =
                await _context.Products.FindAsync(product.ProductId);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.ImageUrl = product.ImageUrl;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetRecommendedProducts(int categoryId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .Take(4)
                .ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetCustomersAlsoBought(int productId)
        {
            // Current product ki category nikal lo
            var currentProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            if (currentProduct == null)
                return new List<Product>();

            // Jin orders mein ye product tha
            var orderIds = await _context.OrderItems
                .Where(oi => oi.ProductId == productId)
                .Select(oi => oi.OrderId)
                .Distinct()
                .ToListAsync();

            // Same orders ke doosre products lao
            var products = await _context.OrderItems
                .Include(oi => oi.Product)
                .Where(oi =>
                    orderIds.Contains(oi.OrderId) &&
                    oi.ProductId != productId)
                .Select(oi => oi.Product!)
                .ToListAsync();

            // Sirf same category ke products rakho
            return products
                .Where(p => p.CategoryId == currentProduct.CategoryId)
                .GroupBy(p => p.ProductId)
                .Select(g => g.First())
                .Take(4)
                .ToList();
        }


    }
    }