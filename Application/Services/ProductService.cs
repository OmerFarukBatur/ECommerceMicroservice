using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Product> GetAllProducts() => _repo.GetAll();
        public Product? GetProductById(int id) => _repo.GetById(id);

        public void CreateProduct(Product product)
        {
            if (product.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            _repo.Add(product);
        }

        public void UpdateProduct(Product product) => _repo.Update(product);
        public void DeleteProduct(int id) => _repo.Delete(id);
    }
}
