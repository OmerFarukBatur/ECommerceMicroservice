using Application.DTOs;
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

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _repo.GetAll().Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name ?? ""
            });
        }
        public ProductDto? GetProductById(int id)
        {
            var product = _repo.GetById(id);
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name ?? ""
            };
        }

        public void CreateProduct(ProductDto dto)
        {
            if (dto.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            if (dto.CategoryId.HasValue == false)
                throw new ArgumentException("CategoryId must be greater than zero.");

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId.Value
            };

            _repo.Add(product);
        }

        public void UpdateProduct(ProductDto dto)
        {
            var product = _repo.GetById(dto.Id);
            if (product == null)
                throw new ArgumentException("Product not found.");

            if (dto.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            if (dto.CategoryId.HasValue == false)
                throw new ArgumentException("CategoryId must be greater than zero.");

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.CategoryId = dto.CategoryId.Value;

            _repo.Update(product);
        }
        public void DeleteProduct(int id) => _repo.Delete(id);
    }
}
