using InventoryManagementSystem.Domain;
using InventoryManagementSystem.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InventoryManagementSystem.Tests
{
    public class ProductRepositoryTests : IDisposable
    {
        private readonly ProductRepository _productRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly SqliteConnection _connection;

        public ProductRepositoryTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseSqlite(_connection)
                          .Options;
            _connection.Open();

            _dbContext = new ApplicationDbContext(options);            
            _dbContext.Database.EnsureCreated();

            _productRepository = new ProductRepository(_dbContext);
        }

        [Fact]
        public async Task AddProductAsync_ShouldAddProduct()
        {
            // Arrange
            var product = new Product
            {
                Name = "Test Product",
                Category = "Test Category",
                Quantity = 10,
            };

            // Act
            await _productRepository.AddProductAsync(product);
            var products = await _productRepository.GetAllProductAsync();

            // Assert
            Assert.Single(products);
            Assert.Equal("Test Product", products.First().Name);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
            _connection.Close();
            _connection.Dispose();
        }
    }
}
