using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04_ProductManager
{
    public class ProductService
    {
        private Repository<Product> repository = new Repository<Product>();
        public event Action<Product> OnProductAdded;
        public event Action<string> OnProductRemoved;

        public void AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Id))
                throw new ArgumentException("Mã sản phẩm không được rỗng.");

            if (repository.FindById(product.Id) != null)
                throw new DuplicateProductException($"Sản phẩm có mã '{product.Id}' đã tồn tại trong kho.");

            repository.Add(product);
            OnProductAdded?.Invoke(product); 
        }

        public void RemoveProduct(string id)
        {
            var product = repository.FindById(id);
            if (product == null)
                throw new ProductNotFoundException($"Không tìm thấy sản phẩm có mã '{id}' để xóa.");

            repository.Remove(product);
            OnProductRemoved?.Invoke(id);
        }

        public IEnumerable<Product> GetAll() => repository.GetAll();

        public Product SearchById(string id) => repository.FindById(id);

        public IEnumerable<Product> Filter(Func<Product, bool> predicate)
        {
            return repository.Find(predicate);
        }

        public decimal CalculateTotalInventoryValue()
        {
            return repository.GetAll().Sum(p => p.Price * p.Quantity);
        }
    }
}