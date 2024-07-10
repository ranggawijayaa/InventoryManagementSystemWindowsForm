using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
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

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnProduct()
        {
            // Arrange
            var product = new Product
            {
                Name = "Test Product",
                Category = "Test Category",
                Quantity = 10,
            };
            await _productRepository.AddProductAsync(product);
            var savedProduct = (await _productRepository.GetAllProductAsync()).First();

            //Act
            var result = await _productRepository.GetProductByIdAsync(savedProduct.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(savedProduct.Id, result.Id);
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldUpdateProduct()
        {
            //Arrange
            var product = new Product
            {
                Name = "Test Product",
                Category = "Test Category",
                Quantity = 10,
            };
            await _productRepository.AddProductAsync(product);
            var savedProduct = (await _productRepository.GetAllProductAsync()).First();

            //Act
            savedProduct.Name = "Updated Product";
            await _productRepository.UpdateProductAsync(savedProduct);
            var updatedProduct = await _productRepository.GetProductByIdAsync(savedProduct.Id);

            //Assert
            Assert.NotNull(updatedProduct);
            Assert.Equal("Updated Product", updatedProduct.Name);
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldDeleteProduct()
        {
            //Arrange
            var product = new Product
            {
                Name = "Test Product",
                Category = "Test Category",
                Quantity = 10,
            };
            await _productRepository.AddProductAsync(product);
            var savedProduct = (await _productRepository.GetAllProductAsync()).First();

            //Act
            await _productRepository.DeleteProductAsync(savedProduct.Id);
            var deletedProduct = await _productRepository.GetProductByIdAsync(savedProduct.Id);

            //Assert
            Assert.Null(deletedProduct);
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
